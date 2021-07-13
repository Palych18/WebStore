using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Areas.Admin.Controllers;
using WebStore.Domain;
using WebStore.Domain.Entities;
using WebStore.Services.Interfaces;
using Assert = Xunit.Assert;

namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {  

        [TestMethod]
        public void Index_Returns_View()
        {
            var configuration_mock = new Mock<IConfiguration>();
            var product_data_mock = new Mock<IProductData>();
            product_data_mock.Setup(s => s.GetProducts(It.IsAny<ProductFilter>()))
               .Returns(Enumerable.Empty<Product>());
            
            var controller = new HomeController(configuration_mock.Object);

            var result = controller.Index(product_data_mock.Object);

            Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void Blog_Returns_View()
        {
            var configuration_mock = new Mock<IConfiguration>();

            var controller = new HomeController(configuration_mock.Object);

            var result = controller.Blog();

            Assert.IsType<ViewResult>(result);
        }        
    }
}
