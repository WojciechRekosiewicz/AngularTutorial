using Microsoft.Extensions.Logging;
using MovieShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.Data
{
    public class FilmRepository : IFilmRepository
    {
        private readonly FilmContext _ctx;
        private readonly ILogger<FilmRepository> _logger;

        public FilmRepository(FilmContext ctx, ILogger<FilmRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("GetAllProducts was called");
                return _ctx.Products
                   .OrderBy(p => p.Title)
                   .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products! {ex}");
                return null;
            }
           
        }


        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _ctx.Products
                    .Where(p => p.Category == category)
                    .ToList();
        }


        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
