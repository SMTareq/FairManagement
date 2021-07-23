using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairManagement.Data;
using FairManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FairManagement.Areas.MVisitor.Controllers
{
    public class VisitorController : Controller
    {
        private ApplicationDbContext _Db;

        public VisitorController(ApplicationDbContext context)
        {
            _Db = context;
        }

        public IActionResult Index()
        {
            try
            {
                var student = _Db.Students.ToList();
                return View(student);
            }
            catch
            {

            }

            return View();
        }

        public IActionResult Details(int id)
        {
            var info = _Db.Visitors.Where(c => c.VisitorId == id).ToList();
            return View(info);

        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Visitor visit)
        {
            if (ModelState.IsValid)
            {
                //visit.Password = BCrypt.Net.BCrypt.HashPassword(visit.Password);
                //visit.ConfirmPassword = BCrypt.Net.BCrypt.HashPassword(visit.ConfirmPassword);
                _Db.Visitors.Add(visit);
                await _Db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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

            var student = _Db.Visitors.Find(id);
            if (student == null)
            {
                return NotFound();
            }


            return View(student);
        }


        public async Task<IActionResult> Edit(Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                _Db.Update(visitor);
                await _Db.SaveChangesAsync();
                TempData["save"] = "Update successfully";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
        //

        public ActionResult Loging()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login( string email, string password)
        {


            var log = Checkvisitor(email, password);
            if(log == null)
            {
                ViewBag.Error = "Account not Found";
                return View("login");
            }
            else
            {
                return RedirectToAction(nameof(Loging));
            }

            //if (visitor.Email == email && visitor.Password == password)
            //{
            //    HttpContext.Session.SetString("email", email);
            //    //return RedirectToAction(nameof(Index));
            //    return View("Loging");
            //}
            //else
            //{
            //    ViewBag.error = "ball abar kor";
            //    return View("SignIn");
            //}
        }

        public Visitor Checkvisitor(string email, string pass)
        {
            var Visit = _Db.Visitors.SingleOrDefault(a => a.Email.Equals(email));
            if (Visit != null)
            {
                if (BCrypt.Net.BCrypt.Verify(pass, Visit.Password))
                {
                    return Visit;
                }
            }
            return null;
        }
    }
}