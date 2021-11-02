using System.Collections.Generic;
using WebShop.Core.Models;

namespace WebShop.Core.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}