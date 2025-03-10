using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ProductsAPI.Data;
using ProductsAPI.Entities;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMemoryCache _cache;
        private readonly DataContext _context;
        private const string ProductCacheKey = "product-list";

        public ProductController(IMemoryCache cache, DataContext context)
        {
            _cache = cache;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            if (!_cache.TryGetValue(ProductCacheKey, out List<Product> products))
            {
                products = GetProductsFromDatabase();

                var options = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                .SetAbsoluteExpiration(TimeSpan.FromDays(1));

                _cache.Set(ProductCacheKey, products, options);
            }

            return Ok(products);
        }

        private List<Product> GetProductsFromDatabase()
        {
            return _context.Products.ToList();
        }
    }
}