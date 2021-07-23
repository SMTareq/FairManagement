using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FairManagement.Areas.Admin.Models;
using FairManagement.Data;
using FairManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FairManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MarkingSchemeController : Controller
    {

        private ApplicationDbContext _Db;

        private IMapper _mapper;

        public MarkingSchemeController(ApplicationDbContext context, IMapper mapper)
        {
            _Db = context;

            _mapper = mapper;


        }
        public IActionResult Index()
        {

            return View(_Db.MarkingScmehes.ToList());
        }

        public IActionResult ProjectView()
        {

            var innerjion= from 




            return View();
        }

        public ActionResult Create()
        {
            List<SelectListItem> projectType = _Db.projectCategories.Select(c => new SelectListItem()
            {
                Value = c.ProjectCategoryId.ToString(),

                Text = c.ProjectType
            }).ToList();


            ViewBag.ProjectT = projectType;
            return View();
        }


        [HttpPost]
        public IActionResult Create(markSchemeVM vM)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<MarkingScmehe>(vM);
                _Db.Add(map);
                bool isval = _Db.SaveChanges() > 0;

                if (isval)
                {
                    return RedirectToAction(nameof(Index)); 
                }
            }
            return View();
        }

    }
}