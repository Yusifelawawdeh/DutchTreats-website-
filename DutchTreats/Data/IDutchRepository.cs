using System.Collections.Generic;
using DutchTreats.Data.Entities;

namespace DutchTreats.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCatagory(string catagory);

        bool SaveAll();
        IEnumerable<Order> GetAllOrders();
    }
}