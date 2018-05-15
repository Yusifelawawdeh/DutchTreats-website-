﻿using DutchTreats.Data.Entities;
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
