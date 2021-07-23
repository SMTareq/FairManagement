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
    public class FairController : Controller
    {
        private ApplicationDbContext _Db;

        public FairController(ApplicationDbContext context)
        {
            _Db = context;
        }
        public IActionResult Index()
        {
            return View(_Db.Fairs.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Fair fair)
        {
            if (ModelState.IsValid)
            {
                _Db.Add(fair);
                await _Db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                ;
            }

            return View();
        }

        //
        public ActionResult Edit(int? id)
        {
            // null able 
            if (id == null)
            {
                return NotFound();
            }

            var student = _Db.Fairs.Find(id);
            if (student == null)
            {
                return NotFound();
            }


            return View(student);
        }


        public async Task<IActionResult> Edit(Fair fair)
        {
            if (ModelState.IsValid)
            {
                _Db.Update(fair);
                await _Db.SaveChangesAsync();
                TempData["save"] = "Update successfully";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}