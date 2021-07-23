using AutoMapper;
using FairManagement.Areas.Admin.Models;
using FairManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairManagement.AutoMapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<markSchemeVM, MarkingScmehe>();

            CreateMap<MarkingScmehe, markSchemeVM>();
        }
        
    }
}
