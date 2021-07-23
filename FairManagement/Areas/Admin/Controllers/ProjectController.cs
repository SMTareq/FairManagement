using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FairManagement.Data;
using FairManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FairManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {

        private ApplicationDbContext _Db;

        private IMapper _mapper;

        public ProjectController(ApplicationDbContext context, IMapper mapper)
        {
            _Db = context;

            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(_Db.Projects.ToList());
        }

        public IActionResult Create()
        {


            List<SelectListItem> projectType = _Db.projectCategories.Select(c => new SelectListItem()
            {
                Value = c.ProjectCategoryId.ToString(),

                Text = c.ProjectType
            }).ToList();


            ViewBag.ProjectT = projectType;


            List<SelectListItem> studentId = _Db.Students.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),

                Text = c.StudentId
            }).ToList();



            ViewBag.studentT = studentId;


            List<SelectListItem> FairId = _Db.Fairs.Select(c => new SelectListItem()
            {
                Value = c.FairId.ToString(),

                Text = c.FairName
            }).ToList();



            ViewBag.fairT = FairId;

            return View();
        }


        

        
        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            if (ModelState.IsValid)
            {
                _Db.Add(project);
                await _Db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            else
            {
                ViewBag.error = "data not save";
            }

            return View();
        }

       
    }
}