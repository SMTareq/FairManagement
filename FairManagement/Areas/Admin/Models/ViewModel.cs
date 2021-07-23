using FairManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairManagement.Areas.Admin.Models
{
    public class ViewModel
    {
        public Student Student { get; set; }

        public Fair Fair { get; set; }

        public Project Project { get; set; }
        public ProjectCategory ProjectCategory { get; set; }

        public MarkingScmehe MarkingScmehe { get; set; }


    }
}
