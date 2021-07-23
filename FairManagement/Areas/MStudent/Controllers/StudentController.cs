using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FairManagement.Areas.MStudent.Models;
using FairManagement.Data;
using FairManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace FairManagement.Areas.MStudent.Controllers
{
    [Area("MStudent")]
    public class StudentController : Controller
    {
        private ApplicationDbContext _Db;

        private IMapper _mapper;

       

        public StudentController(ApplicationDbContext context, IMapper mapper)
        {
            _Db = context;
        
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(_Db.Students.ToList());
        }

        public IActionResult view()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var list = GetStudents(id);
            return View(list);
        }

        public Student GetStudents(int id)
        {
            try
            {
                return _Db.Students.Find(id);
            }
            catch
            {
                throw;
            }
        }

        //
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                //student.Password = BCrypt.Net.BCrypt.HashPassword(student.Password);
                //student.ConfirmPassword = BCrypt.Net.BCrypt.HashPassword(student.ConfirmPassword);
                _Db.Students.Add(student);
                await _Db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public ActionResult Edit(int? id)
        {
            // null able 
            if (id == null)
            {
                return NotFound();
            }

            var student = _Db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }


            return View(student);
        }


        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _Db.Update(student);
                await _Db.SaveChangesAsync();
                TempData["save"] = "Update successfully";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        public ActionResult SignIn()
        {
         

            return View();
        }

        [HttpPost]

        public ActionResult SignIn(Student student, string email, string password)
        {

            if (student.Email == email && student.Password==password)
            {
                //return RedirectToAction(nameof(Index));
             
              
                return View("view");
            }
            else
            {
                ViewBag.error = "ball abar kor";
                return View("SignIn");
            }

            // return View();
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> SignIn(Student student)
        //{

        //    //var map = _mapper.Map<LoginVM>(student);

        //    //var mail = (student.Email = email);

        //    //var passs = (student.Password = pass);

        //    if (student.Password == student.Email)
        //    {
        //       // HttpContext.Session.SetString("email", email);

        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        ViewBag.error = "ball abar kor";
        //        return View("SignIn");
        //    }




        //    //return View(email, pass);
        //    //_Db.Students.FirstOrDefault(c => c.Email.Equals(email));

        //    //Console.WriteLine("pay naa" + email);


        //    //if (BCrypt.Net.BCrypt.Verify(pass, student.Password))
        //    //{
        //    //    Console.WriteLine("pay naa" + pass);
        //    //    HttpContext.Session.SetString("email", email);
        //    //     HttpContext.Session.SetString("email", email);
        //    //}
        //    //else
        //    //{
        //    //    ViewBag.error = "try again";
        //    //    return View("SignIn");
        //    //}


        //    //var student = CheckStudent(email, pass);
        //    //if (student == null)
        //    //{
        //    //    ViewBag.error = "try again";
        //    //    return View("SignIn");
        //    //}
        //    //else
        //    //{
        //    //    HttpContext.Session.SetString("email", email);
        //    //    return View("welcome");
        //    //}


        //    return View();
        //}

        //private Student CheckStudent (string email, string pass)
        //{
        //    var studnet = _Db.Students.FirstOrDefault(c => c.Email.Equals(email) );
        //    Console.WriteLine("pay naa" + email);
        //    var tudnet = _Db.Students.FirstOrDefault(c => c.Password.Equals(pass));
        //    Console.WriteLine("pay naa" + pass);
        //    if (studnet != null)
        //    {
        //        Console.WriteLine("tgkjjdjgjg"+ pass);

        //        Console.WriteLine("tgkjjdj" + studnet.Password);


        //        if (BCrypt.Net.BCrypt.Verify(pass,studnet.Password))
        //        {
        //            return studnet;
        //        }


        //    }

        //    return null;
        //}
    }
}
