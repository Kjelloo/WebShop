using System.Collections.Generic;
using WebShop.Core.Models;

namespace WebShop.Core.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
    }
}