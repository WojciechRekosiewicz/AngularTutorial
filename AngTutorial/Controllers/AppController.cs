using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngTutorial.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
           
            return View();
        }


        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";

            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            ViewBag.Title = "About Us";

            return View();
        }
    }
}
