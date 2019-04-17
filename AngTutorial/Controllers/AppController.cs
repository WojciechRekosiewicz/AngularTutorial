using AngTutorial.ViewModels;
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
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {

            }


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
