using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FairManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}