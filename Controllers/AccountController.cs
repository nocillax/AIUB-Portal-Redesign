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
            return View();
        }

        [HttpPost]
        public ActionResult Register(StudentProfile sp, string Email, string Password)
        {
            if (!ModelState.IsValid)
            {
                return View(sp);
            }
                
            if (_dbContext.Users.Any(u => u.Email == Email))
            {
                ModelState.AddModelError("Email", "Email already exists.");
                return View(sp);
            }

            var user = new User
            {
                Email = Email,
                Password = HashPassword(Password),
                Role = UserRole.Student
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            sp.UserId = user.Id;
            sp.Status = ProfileStatus.Pending;

            _dbContext.StudentProfiles.Add(sp);
            _dbContext.SaveChanges();

            ViewBag.Message = "Registration successful! Wait for admin approval.";
            return RedirectToAction("Register");

        }
    }
}