using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShop.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieShop.Controllers
{

    [Route("api/[Controller]")]
    public class OrdersController : Controller
    {
        private readonly IFilmRepository _repository;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IFilmRepository repository, ILogger<OrdersController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllOrders());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get orders: {ex}");
                return BadRequest("Failed to get orders");
            }
        }



        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
