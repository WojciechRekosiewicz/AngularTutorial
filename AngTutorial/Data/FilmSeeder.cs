using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.Data
{
    public class FilmSeeder
    {
        private readonly FilmContext _ctx;

        public FilmSeeder(FilmContext ctx)
        {
            _ctx = ctx;
        }


        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Products.Any())
            {

            }
        }
    }
}
