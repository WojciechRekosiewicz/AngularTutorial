using MovieShop.Data;
using MovieShop.Services;
using MovieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly FilmContext _context;

        public AppController(IMailService mailService, FilmContext context)
        {
            _mailService = mailService;
            _context = context;
        }


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
                _mailService.SendMessage("ww@gmail.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
        
            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            ViewBag.Title = "About Us";

            return View();
        }

        public IActionResult Shop()
        {
            var results = from p in _context.Products
                          orderby p.Category
                          select p;

            return View(results.ToList());
        }
    }
}
