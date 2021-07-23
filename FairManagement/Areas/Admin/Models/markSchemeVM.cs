using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FairManagement.Areas.Admin.Models
{
    public class markSchemeVM
    {
        [Key]
        public int MarkId { get; set; }
        [Required]

        public int ProjectCategoryId { get; set; }

        public string Mark_Title { get; set; }
        [Required]
        public int SetMark { get; set; }

      
    }
}
