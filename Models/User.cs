using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AIUB_Portal_Redesign.Models
{
    public enum UserRole
    {
        Student,
        Admin
    }

    public class User
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public UserRole Role { get; set; }

        public virtual StudentProfile StudentProfile { get; set; }
    }

}