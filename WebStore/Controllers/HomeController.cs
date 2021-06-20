using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastructure.Mapping;
using WebStore.Domain.Entities;
using WebStore.Services.Interfaces;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {

        private readonly IConfiguration _Configuration;

        public HomeController(IConfiguration Configuration) => _Configuration = Configuration;

        public IActionResult Index([FromServices] IProductData ProductData)
        {
            ViewBag.Products = ProductData.GetProducts().Take(9).ToView();
            return View();
        } 
        public IActionResult Blog() => View();
    }
}
