using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AIUB_Portal_Redesign.Models
{
    public enum ProfileStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public class StudentProfile
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [StringLength(15)]
        public string StudentId { get; set; }

        [Required]
        public string Program { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        public string Address { get; set; }

        public ProfileStatus Status { get; set; } = ProfileStatus.Pending;

        public virtual User User { get; set; }


    }
}