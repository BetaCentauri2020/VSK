using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vsk_betacent.Models;
using vsk_betacent.Models.DataEntities;
using vsk_betacent.Models.ViewModels;

namespace vsk_betacent.Controllers
{
    public class ManageNoticeController : Controller
    {
        private vsk_dbcontext _context;
        public ManageNoticeController(vsk_dbcontext db)
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
        public IActionResult AddNotice(ManageNoticeViewModel addModel)
        {
            int rstatus = 0;string msg = null;
            try
            {
                if (ModelState.IsValid)
                {
                    
                    using (var transaction = _context.Database.BeginTransaction())
                    {

                        var notice = new tbl_notice
                        {
                            txt_title=addModel.addNotice.txt_title,
                            int_proiority=Convert.ToInt32(addModel.addNotice.int_proiority),
                            txt_description=addModel.addNotice.txt_description,
                            dt_dou = DateTime.Now,
                            int_status=0
                        };
                        _context.tbl_notice.Add(notice);
                        int count = _context.SaveChanges();
                        if (count > 0)
                        {
                            transaction.Commit();
                            rstatus = 1;
                            msg = "Notice added successfully.";
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
        public IActionResult ViewNotice(int? type, string msg)
        {
            if (type.HasValue)
                ViewBag.type = type;
            if (!string.IsNullOrEmpty(msg))
                ViewBag.msg = msg;
            var viewModel = new ManageNoticeViewModel()
            {
                noticeList=_context.tbl_notice
                            .Where(x=>x.int_status==0)
                           .OrderByDescending(x=>x.dt_dou) 
                           .ToList()
            };
            return View(viewModel);
        }
        public IActionResult _PartialEditNoticeDetails(int id)
        {
            var Notice = _context.tbl_notice
                           .Where(x => x.int_id == id)
                           .SingleOrDefault();
           
            var viewModel = new ManageNoticeViewModel()
            {
                editNotice =Notice,
            };
            return PartialView(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateNotice(ManageNoticeViewModel editModel)
        {
            int rstatus = 0; string msg = null;
            tbl_notice updateModel = _context.tbl_notice.Where(x => x.int_id == editModel.editNotice.int_id).SingleOrDefault();
            try
            {
                if (ModelState.IsValid)
                {
                    using (var transaction = _context.Database.BeginTransaction())
                    {
                        updateModel.txt_title = editModel.editNotice.txt_title;
                        updateModel.int_proiority = editModel.editNotice.int_proiority;
                        updateModel.txt_description = editModel.editNotice.txt_description;
                        updateModel.dt_dou = DateTime.Now;
                        int count = _context.SaveChanges();
                        if (count > 0)
                        {
                            transaction.Commit();
                            rstatus = 1;
                            msg = "Notice details updated successfully.";
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

            return RedirectToAction("ViewNotice", new { type = rstatus, msg = msg });

        }
        [HttpPost]
        public IActionResult DeleteNotice(int id)
        {
            int rstatus = 0; string msg = null;
            tbl_notice updateModel = _context.tbl_notice.Where(x => x.int_id ==id).SingleOrDefault();
            try
            {
                if (ModelState.IsValid)
                {
                    using (var transaction = _context.Database.BeginTransaction())
                    {
                        updateModel.int_status = 1;
                        updateModel.dt_dou = DateTime.Now;
                        int count = _context.SaveChanges();
                        if (count > 0)
                        {
                            transaction.Commit();
                            rstatus = 1;
                            msg = "Notice has been deleted successfully.";
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

            return RedirectToAction("ViewNotice", new { type = rstatus, msg = msg });

        }
    }
}
