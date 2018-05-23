using System.Collections.Generic;
using DutchTreats.Data.Entities;

namespace DutchTreats.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCatagory(string catagory);

        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetOrderById(int id);

        bool SaveAll();

        void AddEntity(object model);
    }
}