using MovieShop.Data;
using MovieShop.Services;
using MovieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MovieShop.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IFilmRepository _repository;

        public AppController(IMailService mailService, IFilmRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
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

        [Authorize]
        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();

            return View(results.ToList());
        }
    }
}
