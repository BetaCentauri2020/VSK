using System.Data;
using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using vsk_betacent.Models;
using System.Web;
using vsk_betacent.Models.ViewModels;
using vsk_betacent.Models.DataEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims; 
using Microsoft.AspNetCore.Authentication.Cookies;
namespace vsk_betacent.Controllers
{
    
    public class Vsk_adminController : Controller
    {
        private vsk_dbcontext db;
        private readonly IHostingEnvironment _appEnvironment;
        private IConfiguration _config;
        string connString = "";
        private readonly ILogger<Vsk_adminController> _logger;
        SqlConnection SqlConnection;
        public Vsk_adminController(vsk_dbcontext context, IHostingEnvironment appEnvironment, IConfiguration configuration, ILogger<Vsk_adminController> logger)
        {
            _appEnvironment = appEnvironment;
            _config = configuration;
            this.db = context;
            connString = configuration.GetConnectionString("DBConnection");
            SqlConnection = new SqlConnection(connString);
            _logger = logger;
        }
        [HttpPost]
        public IActionResult Admin_Login(IFormCollection form)
        {
            ClaimsIdentity identity = null;
             bool isAuthenticated = false; 
            string uid = form["uid"].ToString();
            string pwd = form["pass"].ToString();
            var _authorizedUser=db.tbl_staff_profile.Where(x=>x.txt_email==uid && x.txt_pwd==CustomUtility.Encrypt(pwd)).SingleOrDefault();
            try
            {
                //if(uid==_config.GetValue<string>("userid").ToString() && pwd==_config.GetValue<string>("password").ToString())  
                if(_authorizedUser!=null)
                {
                   
                    HttpContext.Session.SetString("role","Admin");
                    HttpContext.Session.SetString("Profile",String.IsNullOrEmpty(_authorizedUser.txt_img)?"NA":_authorizedUser.txt_img);
                    HttpContext.Session.SetString("Username",_authorizedUser.txt_email.ToString());
                    return RedirectToAction("Dashboard");
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
        
        public IActionResult Dashboard(int? type, string msg)
        {
            if (type.HasValue)
                ViewBag.type = type;
            if (!string.IsNullOrEmpty(msg))
                ViewBag.msg = msg;
            var viewmodel=new ManageHomeViewModel()
            {
                aluminiList = db.tbl_alumini_details.Where(a=>a.status.Equals(0)).ToList(),
                totalAlumini= db.tbl_alumini_details.ToList().Count(),
                totalInquiry=db.tbl_inquary.ToList().Count(),
                totalStaff=db.tbl_staff_profile.Where(a=>a.int_status==0).ToList().Count()
            };
            return View(viewmodel);
        }
        
        public IActionResult approve_alumini(string regno)
        { int rstatus = 0; string msg = null;
            try
            {
                var stu_res = db.tbl_alumini_details.Where(a => a.registration_number.Equals(regno)).SingleOrDefault();
                stu_res.status = 1;
                stu_res.password=CustomUtility.Encrypt(RandomNumberGenerator.RandomPassword());
                using (var transaction = db.Database.BeginTransaction())
                {
                        int count = db.SaveChanges();
                        if (count > 0)
                        {
                            transaction.Commit();
                            rstatus = 1;
                            msg = "Alumini added successfully.";
                            var subject="VSK Alumini Registration";
                            var body=String.Format("Dear Student,<br/><br/>Your alumini registration for VSK have been approved.<br><u>User Credentials </u><br/>Username : {0}<br/>Password : {1}<br/>URL : http://www.vskunit4.com/<br/><br/>This is a system generated password. So Do not share with anyone.<br/>Thank You.",stu_res.eamil,CustomUtility.Decrypt(stu_res.password));
                            CustomUtility.CustomMail(stu_res.eamil,subject,body);
                        }
                        else{
                            transaction.Rollback();
                            rstatus = 2;
                            msg = "Something went wrong. Try after sometime.";
                        }
                }
               // TempData["approve_msg"] = "Successfully Added New Alumini";
                return RedirectToAction("Dashboard", new { type = rstatus, msg = msg });
            }

            catch (Exception ex)
            {
                return View();
            }
        }
    }
}