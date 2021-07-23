using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairManagement.Data;
using FairManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace FairManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectCategoryController : Controller
    {
        private ApplicationDbContext _Db;

      

        public ProjectCategoryController(ApplicationDbContext context)
        {
            _Db = context;

      
        }
        public IActionResult Index()
        {
            return View(_Db.projectCategories.ToList());
        }

        public ActionResult Create()
        {

             return View();
        }


        [HttpPost]
        public IActionResult Create(ProjectCategory category)
        {
            if (ModelState.IsValid)
            {

                _Db.Add(category);
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