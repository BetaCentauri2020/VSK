using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using vsk_betacent.Models;
using vsk_betacent.Models.DataEntities;
using vsk_betacent.Models.ViewModels;
using System.Threading.Tasks;  
namespace vsk_betacent.Controllers
{
    public class ManageGalleryController : Controller
    {
        private vsk_dbcontext _context;
        public ManageGalleryController(vsk_dbcontext db)
        {
            this._context = db;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IActionResult Index(int? type,string msg)
        {
            if (type.HasValue)
                ViewBag.type = type;
            if (!string.IsNullOrEmpty(msg))
                ViewBag.msg = msg;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGallery(ManageGalleryViewModel addModel)
        {
            int rstatus = 0;string msg = null;
            try
            {
                if (ModelState.IsValid)
                {
                    if (addModel.profilePic.Length > 0)
                    {
                        if(addModel.profilePic.Length  > 2097152)
                           return RedirectToAction("Index", new { type = 2, msg = "Max size 2MB photo can be uploaded" }); 
                        addModel.addImage.txt_file = addModel.profilePic.FileName;
                        using (var stream = System.IO.File.Create(Path.Combine("wwwroot", "Resources","Gallery", addModel.addImage.txt_file)))
                        {
                           await addModel.profilePic.CopyToAsync(stream);
                        }
                    }
                    using (var transaction = _context.Database.BeginTransaction())
                    {

                        var image = new tbl_gallery
                        {
                            txt_title=addModel.addImage.txt_title,
                            int_position=addModel.addImage.int_position.HasValue?addModel.addImage.int_position:null,
                            txt_file=addModel.addImage.txt_file,
                            dt_doc = DateTime.Now,
                            int_status=0
                        };
                        _context.tbl_gallery.Add(image);
                        int count = _context.SaveChanges();
                        if (count > 0)
                        {
                            transaction.Commit();
                            rstatus = 1;
                            msg = "Image uploaded successfully.";
                        }
                    }
                }
                else
                {
                    var errors = ModelState.Select(x => x.Value.Errors)
                                .Where(y => y.Count > 0)
                                .ToList();
                    rstatus = 2;
                    msg = "Something went wrong. Try after sometime.";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return RedirectToAction("Index", new { type = rstatus, msg = msg });

        }
        public IActionResult ViewGallery(int? type, string msg)
        {
            if (type.HasValue)
                ViewBag.type = type;
            if (!string.IsNullOrEmpty(msg))
                ViewBag.msg = msg;
            var viewModel = new ManageGalleryViewModel()
            {
                imageList=_context.tbl_gallery
                           .Where(x=>x.int_status==0)
                           .OrderBy(x=>x.dt_doc) 
                           .ToList()
            };
            return View(viewModel);
        }
        public IActionResult _PartialeditImageDetails(int id)
        {
            var image = _context.tbl_gallery
                           .Where(x => x.int_id == id)
                           .SingleOrDefault();
           
            var viewModel = new ManageGalleryViewModel()
            {
                editImage =image,
            };
            return PartialView(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateImage(ManageGalleryViewModel editModel)
        {
            int rstatus = 0; string msg = null;
            tbl_gallery updateModel = _context.tbl_gallery.Where(x => x.int_id == editModel.editImage.int_id).SingleOrDefault();
            try
            {
                if (ModelState.IsValid)
                {
                    if (editModel.profilePic.Length > 0)
                    {
                        if(editModel.profilePic.Length  > 2097152)
                           return RedirectToAction("ViewGallery", new { type = 2, msg = "Max size 2MB photo can be uploaded" }); 
                        editModel.editImage.txt_file = editModel.profilePic.FileName;

                        using (var stream = System.IO.File.Create(Path.Combine("wwwroot", "Resources","Gallery",  editModel.profilePic.FileName)))
                        {
                           await editModel.profilePic.CopyToAsync(stream);
                        }
                    }
                    else
                    {
                        return RedirectToAction("ViewGallery", new { type = 2, msg = "Something went wrong. Try after sometime." });
                    }
                    using (var transaction = _context.Database.BeginTransaction())
                    {
                        updateModel.txt_title = editModel.editImage.txt_title;
                        updateModel.int_position = editModel.editImage.int_position;
                        updateModel.txt_file = editModel.editImage.txt_file;
                        updateModel.dt_doc = DateTime.Now;
                        int count = _context.SaveChanges();
                        if (count > 0)
                        {
                            transaction.Commit();
                            rstatus = 1;
                            msg = "Image details updated successfully.";
                        }
                    }
                }
                else
                {
                    var errors = ModelState.Select(x => x.Value.Errors)
                                .Where(y => y.Count > 0)
                                .ToList();
                    rstatus = 2;
                    msg = "Something went wrong. Try after sometime.";
                }
            }
            catch(Exception ex)
            {

            }

            return RedirectToAction("ViewGallery", new { type = rstatus, msg = msg });

        }
        [HttpPost]
        public IActionResult DeleteImage(int id)
        {
            int rstatus = 0; string msg = null;
            tbl_gallery updateModel = _context.tbl_gallery.Where(x => x.int_id ==id).SingleOrDefault();
            try
            {
                if (ModelState.IsValid)
                {
                    using (var transaction = _context.Database.BeginTransaction())
                    {
                        updateModel.int_status = 1;
                        updateModel.dt_doc = DateTime.Now;
                        int count = _context.SaveChanges();
                        if (count > 0)
                        {
                            transaction.Commit();
                            rstatus = 1;
                            msg = "Image has been deleted successfully.";
                        }
                    }
                }
                else
                {
                    var errors = ModelState.Select(x => x.Value.Errors)
                                .Where(y => y.Count > 0)
                                .ToList();
                    rstatus = 2;
                    msg = "Something went wrong. Try after sometime.";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("ViewImage", new { type = rstatus, msg = msg });

        }
    }
}
