using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FairManagement.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string StudentId { get; set; }
        [Required]

        public string StudentName { get; set; }
        [Required]
        [EmailAddress]

        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(6)]

        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(6)]
        public string ConfirmPassword { get; set; }

        public bool studentStatus { get; set; }
    }
}
