using System.Collections.Generic;
using System.Linq;
using WebShop.Core.Models;
using WebShop.Core.Repositories;

namespace WebShop.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly WebShopContext _ctx;

        public ProductRepository(WebShopContext ctx)
        {
            _ctx = ctx;
        }


        public IEnumerable<Product> GetProducts()
        {
            var selectQuery = _ctx.Products
                .Select(pe => new Product
                {
                    Id = pe.Id,
                    Name = pe.Name
                });
            return selectQuery.ToList();
        }
    }
}