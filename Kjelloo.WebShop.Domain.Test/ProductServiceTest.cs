using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestPlatform;
using Moq;
using WebShop.Core.Models;
using WebShop.Core.Repositories;
using WebShop.Core.Services;
using WebShop.Domain.Services;
using Xunit;

namespace Kjelloo.WebShop.Domain.Test
{
    public class ProductServiceTest
    {
        [Fact]
        public void ProductServiceIsIProductService()
        {
            var mock = new Mock<IProductRepository>();
            
            var service = new ProductService(mock.Object);
            Assert.True(service is IProductService);
        }

        [Fact]
        public void ProductServiceWithNullProductRepositoryThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new ProductService(null));
        }
        
        [Fact]
        public void ProductServiceWithNullProductRepositoryThrowsExceptionWithMessage()
        {
            var exception = Assert.Throws<InvalidDataException>(() => new ProductService(null));
            Assert.Equal("Repo cannot be null", exception.Message);
        }

        [Fact]
        public void GetProductsCallsProductRepositoriesGetAllExactlyOnce()
        {
            var mock = new Mock<IProductRepository>();
            var service = new ProductService(mock.Object);
            service.GetProducts();
            mock.Verify(r => r.GetAll(), Times.Once);
        }
        
        [Fact]
        public void GetProductsWithoutFilterReturnsListOfAllProducts()
        {
            var expected = new List<Product>
            {
                new Product() {Id = 1, Name = "Product 1"},
                new Product() {Id = 2, Name = "Product 2"}
            };
            
            var mock = new Mock<IProductRepository>();
            mock.Setup(r => r.GetAll())
                .Returns(expected);
            
            var service = new ProductService(mock.Object);
            var actual = service.GetProducts();
            Assert.Equal(expected, actual);
        }
    }
}