using FairManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FairManagement.Areas.Admin.Models
{
    public class ProjectCreateModel
    {
        [Key]
        public int PId { get; set; }
        [Required]

        public string projectName { get; set; }
        [Required]
        [DisplayName("ProjectType")]

        public int ProjectCategoryId { get; set; }

        public string ProjectDescription { get; set; }
        [Required]

        public string ProjectLink { get; set; }


        public bool projectStatus { get; set; }

        public int Id { get; set; }

        public int FairId { get; set; }


    }
}
