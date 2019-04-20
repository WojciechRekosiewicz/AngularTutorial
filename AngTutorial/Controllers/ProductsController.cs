using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShop.Data;
using MovieShop.Data.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieShop.Controllers
{
    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly IFilmRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IFilmRepository repository, ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _repository.GetAllProducts();
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
