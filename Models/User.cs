using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d).{6,}$", ErrorMessage = "Password must contain letters and numbers, and be at least 6 characters.")]
        public string Password { get; set; }


        public UserRole Role { get; set; } = UserRole.Student;

        public virtual StudentProfile StudentProfile { get; set; }

    }

}