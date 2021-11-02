using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kjelloo.WebShop.WebApi.DTOs.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Core.Models;
using WebShop.Core.Services;

namespace Kjelloo.WebShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<ProductDto>> GetProduct()
        {
            var products = _productService.GetProducts();
            if (products.Count != 0)
            {
                return Ok(products);
            }

            return NotFound("No Products Found");
        }
    }
}