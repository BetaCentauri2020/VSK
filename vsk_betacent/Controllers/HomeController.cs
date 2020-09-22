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
using System.Linq.Expressions;
using vsk_betacent.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace vsk_betacent.Controllers
{
    public class HomeController : Controller
    {
        private vsk_dbcontext db;
        private readonly IHostingEnvironment _appEnvironment;
        private IConfiguration _config;
        string connString = "";
        private readonly ILogger<HomeController> _logger;
        SqlConnection SqlConnection;

        public HomeController(vsk_dbcontext context, IHostingEnvironment appEnvironment, IConfiguration configuration, ILogger<HomeController> logger)
        {
            _appEnvironment = appEnvironment;
            _config = configuration;
            this.db = context;
            connString = configuration.GetConnectionString("DBConnection");
            SqlConnection = new SqlConnection(connString);
            _logger = logger;
        }

        public IActionResult Index(int? type,string msg)
        {

            var viewModel=new ManageHomeViewModel(){
                noticeList=db.tbl_notice.Where(x=>x.int_status==0 && x.int_proiority!=3).OrderByDescending(x=>x.dt_dou).ToList()
            };
            return View(viewModel);
        }
        public IActionResult _PartialLogIn()
        {
            return PartialView();
        }
        [HttpGet]
        public IActionResult alumini_registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult alumini_registration(tbl_alumini_details alumini, IFormCollection form, IFormFile file)
        {
            try

            {
                string renameFile = "";
                var folderName = Path.Combine("wwwroot","Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (!Directory.Exists(pathToSave))
                {
                    Directory.CreateDirectory(pathToSave);

                }
                if (file.Length > 0)
                {
                    DateTime dt = DateTime.Now;
                    string dateOnly = dt.Date.ToShortDateString();
                    string finaldate = dateOnly.Replace(@"-", string.Empty);
                    Random generator = new Random();
                    int no = generator.Next(10000, 100000);
                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    renameFile = Convert.ToString(Guid.NewGuid()) + "." + filename.Split('.').Last();
                    //var filename = actual_filename + "_" + no + "_" + dateOnly;
                    var fullPath = Path.Combine(pathToSave, renameFile);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                Guid id = Guid.NewGuid();
                alumini.registration_number = id.ToString();
                alumini.file = renameFile;
                //alumini.gender = form["radio"].ToString();
                //alumini.marital_status = form["status"].ToString();
                if (ModelState.IsValid)
                {
                    db.Add(alumini);
                    db.SaveChanges();
                    TempData["regmsg"] = "You have registered Successfully";
                    
                }
                return RedirectToAction("alumini_registration");
            }

            catch (Exception ex)
            {
                return View();
            }
        }
        public IActionResult AddInquery()
        {
            return RedirectToAction("alumini_registration");
        }
        public IActionResult admission()
        {
            return View();
        }
        public IActionResult Faculty()
        {
            var viewModel=new ManageStaffViewModel(){
                staffList=db.tbl_staff_profile
                        .Where(x=>x.int_status==0)
                        .Include(x=>x.desg_id)
                        .ToList()
            };
            return View(viewModel);
        }
        public IActionResult Galery()
        {
            var viewModel=new ManageGalleryViewModel()
            {
                imageList=db.tbl_gallery.Where(x=>x.int_status==0).ToList()
            };
            return View(viewModel);
        }
        public IActionResult alumini_details()
        {
            var viewModel=new ManageAluminiViewModel()
            {
                aluminiList=db.tbl_alumini_details.ToList()
            } ;
            return View(viewModel);
        }
        public IActionResult contactus()
        {
            return View();
        }
        public IActionResult AboutHistory()
        {
            return View();
        }
        public IActionResult AboutMV()
        {
            return View();
        }
        public IActionResult Messages()
        {
            return View();
        }
        public IActionResult Courses()
        {
            return View();
        }
        public IActionResult Activities()
        {
            return View();
        }
        public IActionResult Calendar()
        {
            return View();
        }
        
    }
}
