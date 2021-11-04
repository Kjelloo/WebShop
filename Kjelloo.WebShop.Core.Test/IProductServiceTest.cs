using System.Collections.Generic;
using Moq;
using WebShop.Core.Models;
using WebShop.Core.Services;
using Xunit;

namespace Kjelloo.WebShop.Core.Test
{
    public class IProductServiceTest
    {
        [Fact]
        public void IProductServiceIsAvailable()
        {
            var service = new Mock<IProductService>().Object;
            Assert.NotNull(service);
        }

        [Fact]
        public void GetProductWithNoParamsReturnsListOfAllProducts()
        {
            var mock = new Mock<IProductService>();
            var fakeList = new List<Product>();
            mock.Setup(s => s.GetProducts())
                .Returns(fakeList);
            var service = mock.Object;
            
            Assert.Equal(fakeList, service.GetProducts());
        }
    }
    
}