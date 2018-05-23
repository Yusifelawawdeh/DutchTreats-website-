using DutchTreats.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreats.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext _ctx;
        private readonly ILogger<DutchRepository> _logger;

        public DutchRepository(DutchContext ctx, ILogger<DutchRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            try
            {
                if (includeItems)
                {

                    return _ctx.Orders
                        .Include(o => o.Items)
                        .ThenInclude(i => i.Product)
                        .ToList();
                }
                else
                {
                    return _ctx.Orders.ToList();

                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all orders: {ex}");
                return null;

            }
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
                _logger.LogError($"Failed to Get all Products: {ex} ");
                return null;
            }
        }

        public IEnumerable<Product> GetProductsByCatagory(string catagory)
        {
            try
            {

                return _ctx.Products
                    .Where(p => p.Category == catagory)
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products by catagory: {ex}");
                return null;
            }
        }

        public Order GetOrderById(int id)
        {
            try
            {
                return _ctx.Orders
                    .Include(i => i.Items)
                    .ThenInclude(i => i.Product)
                    .Where(o => o.Id == id)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get Order by Id: {ex}");
                return null;
            }
        }

        public bool SaveAll()
        {
            try
            {
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products by catagory: {ex}");
                return false;
            }
        }

    }
}
