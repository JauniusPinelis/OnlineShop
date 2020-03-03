using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DeleteProduct;
using Shop.Application.GetProduct;
using Shop.Application.GetProducts;
using Shop.Application.ProductsAdmin;
using Shop.Application.UpdateProduct;
using Shop.Database;

namespace Shop.UI.Controllers
{
    [Route("[Controller]")]
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
        
        [HttpPost("products")]
        public IActionResult CreateProduct(CreateProduct.ProductViewModel vm) => Ok(new CreateProduct(_ctx).Do(vm));

        [HttpDelete("products/{id}")]
        public IActionResult DeleteProduct(int id) => Ok(new DeleteProduct(_ctx).Do(id));

        [HttpPut("products")]
        public IActionResult GetProducts(UpdateProduct.ProductViewModel vm) => Ok(new UpdateProduct(_ctx).Do(vm));
    }
}