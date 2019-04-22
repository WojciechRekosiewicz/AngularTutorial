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
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IFilmRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IFilmRepository repository, ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }



        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                //return Ok(_repository.GetAllOrders(true));
                return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products {ex}");
                return BadRequest("Failed to get all products");
            }
        }
    }
}
