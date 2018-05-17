﻿using DutchTreats.Data;
using DutchTreats.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreats.Controllers
{
    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly IDutchRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IDutchRepository repository, ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                return Ok(_repository.GetAllProducts());

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get Products: {ex}");
                return BadRequest("Failed to get products");
            }
        }

    }
}
