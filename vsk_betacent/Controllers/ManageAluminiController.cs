using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vsk_betacent.Models;
using vsk_betacent.Models.DataEntities;
using vsk_betacent.Models.ViewModels;

namespace vsk_betacent.Controllers
{
    public class ManageAluminiController : Controller
    {
        private vsk_dbcontext _context;
        public ManageAluminiController(vsk_dbcontext db)
        {
            this._context = db;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [HttpPost]
        public IActionResult Admin_Login(IFormCollection form)
        {
            string uid = form["auid"].ToString();
            string pwd = form["apass"].ToString();
            var isAuthorisedUser=_context.tbl_alumini_details
                                .Where(x=>x.eamil==uid && x.password==CustomUtility.Encrypt(pwd)).SingleOrDefault();
            try
            {
                if(isAuthorisedUser!=null)
                {
                    HttpContext.Session.SetString("role","Alumini");
                    HttpContext.Session.SetString("RegdNo",isAuthorisedUser.registration_number);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index","Home",new { type = 2, msg = "Unauthorized User" });
                }
            }
            catch(Exception ex)
            {
                
                throw;
            }
           
        }
        public IActionResult Index(int? type,string msg)
        {
            if (type.HasValue)
                ViewBag.type = type;
            if (!string.IsNullOrEmpty(msg))
                ViewBag.msg = msg;
            var viewModel = new ManageAluminiViewModel() { 
                alumini=_context.tbl_alumini_details.Where(x=>x.registration_number==HttpContext.Session.GetString("RegdNo").ToString()).SingleOrDefault()
            };
            return View(viewModel);
        }
       
        public IActionResult ViewAlumini(int? type, string msg)
        {
            if (type.HasValue)
                ViewBag.type = type;
            if (!string.IsNullOrEmpty(msg))
                ViewBag.msg = msg;
            var viewModel = new ManageAluminiViewModel()
            {
                aluminiList = _context.tbl_alumini_details.ToList()
            };
            return View(viewModel);
        }
        public IActionResult _PartialEditAluminiDetails(int id)
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
                subAreaForStaff= staff.txt_fk_sub_area.Split(',').Select(n => Convert.ToInt32(n)).ToArray() 
            };
            return PartialView(viewModel);
        }
        public IActionResult _PartialViewAluminiDetails(string regd)
        {
            var viewModel = new ManageAluminiViewModel() { 
                alumini=_context.tbl_alumini_details.Where(x=>x.registration_number==regd).SingleOrDefault()
            };
            return PartialView(viewModel);
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
                           .Where(x=>x.int_status==0 && x.int_proiority==3)
                           .OrderByDescending(x=>x.dt_dou) 
                           .ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ResetPassword(ManageAluminiViewModel editModel)
        {
            int rstatus = 0; string msg = null;
            tbl_alumini_details updateModel = _context.tbl_alumini_details.Where(x => x.registration_number == editModel.alumini.registration_number).SingleOrDefault();
            try
            {
                if(updateModel!=null)
                {
                    if (editModel.password==editModel.confirmPassword)
                    {
                        using (var transaction = _context.Database.BeginTransaction())
                        {
                            updateModel.password = CustomUtility.Encrypt(editModel.password);
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
            return RedirectToAction("Index", new { type = rstatus, msg = msg });

        }
        
    }
}
