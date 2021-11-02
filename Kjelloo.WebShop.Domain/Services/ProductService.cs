using System.Collections.Generic;
using System.Linq;
using WebShop.Core.Models;
using WebShop.Core.Repositories;
using WebShop.Core.Services;

namespace WebShop.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;

        public ProductService(IProductRepository productRepository)
        {
            _productRepo = productRepository;
        }

        public List<Product> GetProducts()
        {
            return _productRepo.GetProducts().ToList();
        }
    }
}