using System.Collections.Generic;
using MovieShop.Data.Entities;

namespace MovieShop.Data
{
    public interface IFilmRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);

        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetOrderById(int id);
        bool SaveAll();
        void AddEntity(object model);
    }
}