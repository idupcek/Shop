﻿using Microsoft.AspNetCore.Mvc;
using Shop.Application.ProductAdmin;
using Shop.Application.ProductsAdmin;
using Shop.Database;

namespace Shop.UI.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _ctx;

        public AdminController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("products")]
        public IActionResult GetProducts() => Ok(new GetProducts(_ctx).Do());

        [HttpGet("products/{id}")]
        public IActionResult GetProduct(int id) => Ok(new GetProduct(_ctx).Do(id));

        [HttpPost]
        public IActionResult CreateProducts(CreateProduct.ProductViewModel vm) => Ok(new GetProducts(_ctx).Do());

        [HttpDelete("products/{id}")]
        public IActionResult DeleteProduct(int id) => Ok(new DeleteProduct(_ctx).Do(id));

        [HttpPut("products")]
        public IActionResult UpdateProducts(UpdateProduct.ProductViewModel vm) => Ok(new UpdateProduct(_ctx).Do(vm));
    }
}