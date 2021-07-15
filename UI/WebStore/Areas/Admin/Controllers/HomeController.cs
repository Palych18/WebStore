using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using WebStore.Domain.Entities.Identity;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = Role.Administrators)]
    public class HomeController : Controller
    {
        public HomeController(IConfiguration @object)
        {
            Object = @object;
        }

        public IConfiguration Object { get; }

        public IActionResult Index(Services.Interfaces.IProductData @object)
        {
            return View();
        }

        public object Blog()
        {
            throw new NotImplementedException();
        }

        public object SecondAction()
        {
            throw new NotImplementedException();
        }

        public void Throw(string expected_error_message)
        {
            throw new NotImplementedException();
        }
    }
}
