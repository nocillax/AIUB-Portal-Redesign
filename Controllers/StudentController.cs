using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIUB_Portal_Redesign.Controllers
{
    public class StudentController : Controller
    {

        public ActionResult Index()
        {
            if (Session["UserRole"] != "Student")
            {
                return RedirectToDashboard();
            }

            return View();
        }

        public ActionResult Applications()
        {
            return View();
        }

        public ActionResult CourseDetails()
        {
            return View();
        }

        public ActionResult DownloadForms()
        {
            return View();
        }
    }
}