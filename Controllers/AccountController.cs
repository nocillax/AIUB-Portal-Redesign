using AIUB_Portal_Redesign.Context;
using AIUB_Portal_Redesign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AIUB_Portal_Redesign.Controllers
{
    public class AccountController : Controller
    {
        private AppDbContext _dbContext;

        public AccountController()
        {
            this._dbContext = new AppDbContext();
        }


        private ActionResult RedirectToDashboard()
        {
            var role = Session["UserRole"]?.ToString();

            switch (role)
            {
                case "Admin":
                    return RedirectToAction("Index", "Admin");

                case "Student":
                    return RedirectToAction("Index", "Student");

                default:
                    return RedirectToAction("Login", "Account");
            }
        }


        private string HashPassword(string password)
        {
            using(SHA256 sha256 = SHA256.Create())
    {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public ActionResult Register()
        {
            if (Session["UserId"] != null)
            {
                return RedirectToDashboard();
            }

            return View();
        }

        [HttpPost]
        public ActionResult Register(StudentProfile sp)
        {
            if (Session["UserId"] != null)
            {
                return RedirectToDashboard();
            }

            string confirmPassword = Request.Form["ConfirmPassword"];

            if (!ModelState.IsValid)
            {
                return View(sp);
            }

            if (sp.Password != confirmPassword)
            {
                ModelState.AddModelError("Password", "Passwords do not match.");
                return View(sp);
            }

            if (_dbContext.Users.Any(u => u.Email == sp.Email))
            {
                ModelState.AddModelError("Email", "Email already exists.");
                return View(sp);
            }

            var user = new User
            {
                FullName = sp.FullName,
                Email = sp.Email,
                Password = HashPassword(sp.Password),
                Role = UserRole.Student
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            sp.UserId = user.Id;
            sp.Status = ProfileStatus.Pending;

            _dbContext.StudentProfiles.Add(sp);

            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong while saving. Please try again.");
                return View(sp);
            }


            ViewBag.Message = "Registration successful!";
            return RedirectToAction("Register");
        }

        public ActionResult Login()
        {
            if (Session["UserId"] != null)
            {
                return RedirectToDashboard();
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(string email,  string password)
        {
            if (Session["UserId"] != null)
            {
                return RedirectToDashboard();
            }
                
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Email and Password are required.";
                return View();
            }

            string hashedPassword  = HashPassword(password);
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == hashedPassword);

            if (user == null)
            {
                ViewBag.Error = "Invalid email or password.";
                return View();
            }
          
            if (user.Role == UserRole.Student)
            {
                var profile = _dbContext.StudentProfiles.FirstOrDefault(p => p.UserId == user.Id);
                if (profile == null)
                {
                    ViewBag.Error = "Your profile is not available.";
                    return View(); 
                }
                else if (profile.Status != ProfileStatus.Approved)
                {
                    ViewBag.Error = "Your profile is pending approval.";
                    return View();
                }

            }

            Session["UserId"] = user.Id;
            Session["UserRole"] = user.Role.ToString();
            Session["UserEmail"] = user.Email;
            Session["UserName"] = user.FullName ?? "Guest";


            if (user.Role == UserRole.Admin)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Student");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }


    }
}