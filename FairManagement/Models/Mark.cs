using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FairManagement.Models
{
    public class Mark
    {
        [Key]
        public int TMarkId { get; set; }
        [Required]
        public int SubmitMark { get; set; }

        public int MarkId { get; set; }
        public MarkingScmehe MarkingScmehe { get; set; }

        public int VisitorId { get; set; }
        public Visitor Visitor { get; set; }




    }
}
