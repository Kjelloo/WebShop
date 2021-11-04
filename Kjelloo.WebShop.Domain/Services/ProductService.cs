using System.Collections.Generic;
using System.IO;
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
            if (productRepository == null)
            {
                throw new InvalidDataException("Repo cannot be null");
            }
            
            _productRepo = productRepository;
        }

        public List<Product> GetProducts()
        {
            return _productRepo.GetAll().ToList();
        }
    }
}