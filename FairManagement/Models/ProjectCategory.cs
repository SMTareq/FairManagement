using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FairManagement.Models
{
    public class ProjectCategory
    {
        [Key]
        public int ProjectCategoryId { get; set; }
        [Required]
        public string ProjectType { get; set; }
        [Required]
        public int ProjectMark { get; set; }
    }
}
