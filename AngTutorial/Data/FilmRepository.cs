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

        public FilmRepository(FilmContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _ctx.Products
                    .OrderBy(p => p.Title)
                    .ToList();
        }


        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _ctx.Products
                    .Where(p => p.Category == category)
                    .ToList();
        }
    }
}
