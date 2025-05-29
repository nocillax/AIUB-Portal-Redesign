using AIUB_Portal_Redesign.Context;
using AIUB_Portal_Redesign.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AIUB_Portal_Redesign.Controllers
{
    public class AdminController : Controller
    {
        private AppDbContext _dbContext;

        public AdminController()
        {
            this._dbContext = new AppDbContext();
        }

        private bool IsAdmin()
        {
            return Session["UserRole"] != null && Session["UserRole"].ToString() == "Admin";
        }

        public ActionResult Index()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            var profiles = _dbContext.StudentProfiles 
                .Include("User")
                .Where(sp => sp.Status == ProfileStatus.Pending) 
                .ToList();

            return View(profiles);
        }

        [HttpPost]
        public ActionResult Approve(int id)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            var profile = _dbContext.StudentProfiles.Find(id);

            if (profile != null)
            {
                profile.Status = ProfileStatus.Approved;
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Reject(int id)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }  

            var profile = _dbContext.StudentProfiles.Find(id);

            if (profile != null)
            {
                profile.Status = ProfileStatus.Rejected;
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}