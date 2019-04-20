using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using MovieShop.Data.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.Data
{
    public class FilmSeeder
    {
        private readonly FilmContext _ctx;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<StoreUser> _userManager;

        public FilmSeeder(FilmContext ctx, IHostingEnvironment hosting, UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }


        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();


            StoreUser user = await _userManager.FindByEmailAsync("tony@stark.com");
            if(user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "Tony",
                    LastName = "Stark",
                    Email = "tony@stark.com",
                    UserName = "tony@stark.com"
                };


                var result = await _userManager.CreateAsync(user, "IronMan1!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Couldn't create new user in seeder");
                }
            }



            if (!_ctx.Products.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _ctx.Products.AddRange(products);

                var order = _ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if(order != null)
                {
                    order.User = user;
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price
                        }
                    };
                }

                _ctx.SaveChanges();
            }
        }
    }
}
