using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FairManagement.Models
{
    public class MarkingScmehe
    {
        [Key]
        public int MarkId { get; set; }
        [Required]

        public string Mark_Title { get; set; }
        [Required]
        public int SetMark { get; set; }

        public int ProjectCategoryId { get; set; }

        public ProjectCategory ProjectCategory { get; set; }
    }
}
