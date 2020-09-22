using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using vsk_betacent.Models;
using vsk_betacent.Models.ViewModels;

namespace vsk_betacent.Controllers
{
    public class ManageInquaryController : Controller
    {
        private vsk_dbcontext _context;
        public ManageInquaryController(vsk_dbcontext _context)
        {
            this._context = _context;
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
            var viewModel = new ManageInquaryViewModel() { 
                inquaryList=_context.tbl_inquary.OrderByDescending(x=>x.dt_doi).ToList()
            };
            return View(viewModel);
        }
       [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddInquary(ManageHomeViewModel addModel)
        {
            int rstatus = 0;string msg = null;
            try{
                if(ModelState.IsValid)
                {
                    using (var transaction = _context.Database.BeginTransaction())
                    {
                        var user = new tbl_inquary
                        {
                            name = addModel.inquary.name,
                            course = addModel.inquary.course,
                            email = addModel.inquary.email,
                            Contact_no = addModel.inquary.Contact_no,
                            query = addModel.inquary.query,
                            dt_doi=DateTime.Now
                        };
                        _context.tbl_inquary.Add(user);
                        int count = _context.SaveChanges();
                        if (count > 0)
                        {
                            transaction.Commit();
                            rstatus = 1;
                            msg = "Query Submitted Successfully.";
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
                rstatus = 2;
                msg = "Something went wrong. Try after sometime.";
            }
            return RedirectToAction("Index","Home",new { type = rstatus, msg = msg });
        }
    }
}
