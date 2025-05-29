using System.Web.Mvc;

namespace AIUB_Portal_Redesign.Controllers
{
    public class StudentController : Controller
    {
        private bool IsStudent()
        {
            return Session["UserRole"]?.ToString() == "Student";
        }

        public ActionResult Index()
        {
            if (!IsStudent())
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        public ActionResult Applications()
        {
            if (!IsStudent())
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        public ActionResult CourseDetails()
        {
            if (!IsStudent())
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        public ActionResult DownloadForms()
        {
            if (!IsStudent())
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}