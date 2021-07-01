using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSrore.Interfaces;
using WebStore.Services.Interfaces;

namespace WebStore.WebAPI.Controllers
{
    [Route(WebAPIAddress.Products)]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        private readonly IProductData _ProductData;

        public ProductsApiController(IProductData ProductData) => _ProductData = ProductData;
    }
}
