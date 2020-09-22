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
using Microsoft.AspNetCore.Http;
namespace vsk_betacent.Controllers
{
    public class ManageStaffController : Controller
    {
        private vsk_dbcontext _context;
        public ManageStaffController(vsk_dbcontext db)
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
            var viewModel = new ManageStaffViewModel() { 
                bloodGroupList=_context.tbl_blood_gr.ToList(),
                desigTypeList=_context.tbl_desig_type.ToList(),
                profesnList=_context.tbl_profesn.ToList(),
                quaificationList=_context.tbl_qualification.ToList(),
                subAreaList=_context.tbl_sub_area_type.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStaff(ManageStaffViewModel addModel)
        {
            int rstatus = 0;string msg = null;
            try
            {
                if (_context.tbl_staff_profile.Any(x => x.txt_email == addModel.addStaff.txt_email)) //Already Exist
                {
                    return RedirectToAction("Index", new { type =3,msg="Staff already exist" });
                }
                else
                {
                    
                    if (ModelState.IsValid)
                    {
                        if (addModel.profilePic!=null && addModel.profilePic.Length > 0)
                        {
                            if(addModel.profilePic.Length  > 2097152)
                                return RedirectToAction("Index", new { type = 2, msg = "Max size 2MB photo can be uploaded" }); 
                            addModel.addStaff.txt_img = addModel.profilePic.FileName;

                            using (var stream = System.IO.File.Create(Path.Combine("wwwroot", "resources","Profile", addModel.addStaff.txt_img)))
                            {
                                await addModel.profilePic.CopyToAsync(stream);
                            }
                        }
                        using (var transaction = _context.Database.BeginTransaction())
                        {

                            var user = new tbl_staff_profile
                            {
                                txt_nm = addModel.addStaff.txt_nm,
                                int_fk_qua = addModel.addStaff.int_fk_qua,
                                int_fk_prof = addModel.addStaff.int_fk_prof,
                                int_fk_desg = addModel.addStaff.int_fk_desg,
                                txt_fk_sub_area =addModel.addStaff.int_fk_sub_area!=null ? string.Join(",", addModel.addStaff.int_fk_sub_area) : null,
                                dt_dob = addModel.addStaff.dt_dob,
                                int_gen = addModel.addStaff.int_gen,
                                txt_mob = addModel.addStaff.txt_mob,
                                txt_email = addModel.addStaff.txt_email,
                                int_fk_bld_grp = addModel.addStaff.int_fk_bld_grp,
                                txt_address = addModel.addStaff.txt_address,
                                txt_img = addModel.addStaff.txt_img,
                                //txt_pwd = CustomUtility.Encrypt(RandomNumberGenerator.RandomPassword()),
                                int_status = 0,
                                dt_doc = DateTime.Now


                            };
                            _context.tbl_staff_profile.Add(user);
                            int count = _context.SaveChanges();
                            if (count > 0)
                            {
                                transaction.Commit();
                                //CustomUtility.SendMail(addModel.addStaff.txt_nm, addModel.addStaff.txt_email, CustomUtility.Decrypt(user.txt_pwd), addModel.addStaff.txt_email);
                                rstatus = 1;
                                msg = "Staff added successfully.";
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return RedirectToAction("Index", new { type = rstatus, msg = msg });

        }
        public IActionResult ViewStaff(int? type, string msg)
        {
            if (type.HasValue)
                ViewBag.type = type;
            if (!string.IsNullOrEmpty(msg))
                ViewBag.msg = msg;
            var viewModel = new ManageStaffViewModel()
            {
                bloodGroupList = _context.tbl_blood_gr.ToList(),
                desigTypeList = _context.tbl_desig_type.ToList(),
                profesnList = _context.tbl_profesn.ToList(),
                quaificationList = _context.tbl_qualification.ToList(),
                subAreaList = _context.tbl_sub_area_type.ToList(),
                staffList=_context.tbl_staff_profile
                           .Include(x=>x.bld_id)
                           .Include(x=>x.desg_id)
                           .Include(x=>x.prof_id)
                           .Include(x=>x.qualif_id)
                           .ToList()
            };
            return View(viewModel);
        }
        public IActionResult _PartialEditStaffDetails(int id)
        {
            var staff = _context.tbl_staff_profile
                           .Where(x => x.int_id == id)
                           .Include(x => x.bld_id)
                           .Include(x => x.desg_id)
                           .Include(x => x.prof_id)
                           .Include(x => x.qualif_id)
                           .SingleOrDefault();
           
            var viewModel = new ManageStaffViewModel()
            {
                bloodGroupList = _context.tbl_blood_gr.ToList(),
                desigTypeList = _context.tbl_desig_type.ToList(),
                profesnList = _context.tbl_profesn.ToList(),
                quaificationList = _context.tbl_qualification.ToList(),
                subAreaList = _context.tbl_sub_area_type.ToList(),
                editStaff =staff,
                subAreaForStaff=staff.txt_fk_sub_area!=null? staff.txt_fk_sub_area.Split(',').Select(n => Convert.ToInt32(n)).ToArray() :null
            };
            return PartialView(viewModel);
        }
        public IActionResult _PartialViewStaffDetails(int id)
        {
            var viewModel = new ManageStaffViewModel()
            {
                subAreaList = _context.tbl_sub_area_type.ToList(),
                editStaff = _context.tbl_staff_profile
                           .Where(x => x.int_id == id)
                           .Include(x => x.bld_id)
                           .Include(x => x.desg_id)
                           .Include(x => x.prof_id)
                           .Include(x => x.qualif_id)
                           .SingleOrDefault()
            };
            return PartialView(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStaff(ManageStaffViewModel editModel)
        {
            int rstatus = 0; string msg = null;
            tbl_staff_profile updateModel = _context.tbl_staff_profile.Where(x => x.int_id == editModel.editStaff.int_id).SingleOrDefault();
            try
            {
                if (ModelState.IsValid)
                {
                    using (var transaction = _context.Database.BeginTransaction())
                    {
                        updateModel.int_fk_prof = editModel.editStaff.int_fk_prof;
                        updateModel.int_fk_desg = editModel.editStaff.int_fk_desg;
                        updateModel.txt_fk_sub_area =editModel.subAreaForStaff!=null? string.Join(",", editModel.subAreaForStaff):null;
                        updateModel.txt_mob = editModel.editStaff.txt_mob;
                        updateModel.txt_email = editModel.editStaff.txt_email;
                        updateModel.txt_address = editModel.editStaff.txt_address;
                        updateModel.dt_dom = DateTime.Now;
                        int count = _context.SaveChanges();
                        if (count > 0)
                        {
                            transaction.Commit();
                            rstatus = 1;
                            msg = "Staff details updated successfully.";
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

            return RedirectToAction("ViewStaff", new { type = rstatus, msg = msg });

        }
        [HttpPost]
        public IActionResult DiscontinueStaff(int id)
        {
            int rstatus = 0; string msg = null;
            tbl_staff_profile updateModel = _context.tbl_staff_profile.Where(x => x.int_id ==id).SingleOrDefault();
            try
            {
                if (ModelState.IsValid)
                {
                    using (var transaction = _context.Database.BeginTransaction())
                    {
                        updateModel.int_status = 1;
                        updateModel.dt_dom = DateTime.Now;
                        int count = _context.SaveChanges();
                        if (count > 0)
                        {
                            transaction.Commit();
                            rstatus = 1;
                            msg = "Staff has been discontinued successfully.";
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

            return RedirectToAction("ViewStaff", new { type = rstatus, msg = msg });

        }
        public IActionResult Profile(int? type,string msg)
        {
            if (type.HasValue)
                ViewBag.type = type;
            if (!string.IsNullOrEmpty(msg))
                ViewBag.msg = msg;
            var viewModel = new ManageStaffViewModel() { 
                editStaff=_context.tbl_staff_profile
                         .Where(x=>x.txt_email==HttpContext.Session.GetString("Username").ToString())
                         .Include(x=>x.prof_id)
                         .Include(x=>x.desg_id)
                         .SingleOrDefault()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ResetPassword(ManageStaffViewModel editModel)
        {
            int rstatus = 0; string msg = null;
            tbl_staff_profile updateModel = _context.tbl_staff_profile.Where(x => x.txt_email == editModel.editStaff.txt_email).SingleOrDefault();
            try
            {
                if(updateModel!=null)
                {
                    if (editModel.password==editModel.confirmPassword)
                    {
                        using (var transaction = _context.Database.BeginTransaction())
                        {
                            updateModel.txt_pwd = CustomUtility.Encrypt(editModel.password);
                            int count = _context.SaveChanges();
                            if (count > 0)
                            {
                                transaction.Commit();
                                rstatus = 1;
                                msg = "Password updated successfully.";
                            }
                        }
                    }
                    else
                    {
                        rstatus = 3;
                        msg = "Password does not match. Try Again.";
                    }
                }
                else{
                    rstatus = 2;
                    msg = "Something went wrong. Try Again.";
                }
            }
            catch(Exception ex)
            {
                rstatus = 2;
                msg = "Something went wrong. Try Again.";
            }
            return RedirectToAction("Profile", new { type = rstatus, msg = msg });

        }
    }
}
