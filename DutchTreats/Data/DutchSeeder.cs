﻿using DutchTreats.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreats.Data
{
    public class DutchSeeder
    {
        private readonly DutchContext _ctx;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<StoreUser> _userManager;

        public DutchSeeder(DutchContext ctx, IHostingEnvironment hosting, UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            _ctx.Database.EnsureCreated();

            var user = await _userManager.FindByEmailAsync("atlasbishop@outlook.com");

            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "atlas",
                    LastName = "bishop",
                    UserName = "atlasbishop@outlook.com",
                    Email = "atlasbishop@outlook.com"
                };

                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create new user");
                }
            }

            if (!_ctx.Products.Any())
            {
                // need to create sample data 
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);

                _ctx.Products.AddRange(products);

                var order = new Order()
                {
                    OrderDate = DateTime.Now,
                    OrderNumber = "12345",
                    User = user,
                    Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                        Product = products.First(),
                        Quantity = 5,
                        UnitPrice = products.First().Price
                        }
                    }

                };

                _ctx.Orders.Add(order);
                _ctx.SaveChanges();
            }
        }
    }
}
