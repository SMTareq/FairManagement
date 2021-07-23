using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FairManagement.Models
{
    public class Project
    {
        [Key]
        public int PId { get; set; }
        [Required]

        public string projectName { get; set; }
        [Required]


        public string ProjectDescription { get; set; }
        [Required]

        public string ProjectLink { get; set; }


        public bool projectStatus { get; set; }

        public int Id { get; set; }

        public Student Student { get; set; }

        public int FairId { get; set; }
        public Fair Fair { get; set; }

        public int ProjectCategoryId { get; set; }

        public ProjectCategory ProjectCategory { get; set; }
    }
}
