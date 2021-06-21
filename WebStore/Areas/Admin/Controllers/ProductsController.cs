using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Identity;
using WebStore.Services.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = Role.Administrators)]
    public class ProductsController : Controller
    {
        private readonly IProductData _ProductData;

        public ProductsController(IProductData ProductData) => _ProductData = ProductData;

        public IActionResult Index() => View(_ProductData.GetProducts());
        
        public IActionResult Edit(ProductViewModel Model)
        {
            if (!ModelState.IsValid)
                return View(Model);            

            var employee = new Product
            {
                Id = Model.Id,                
                Name = Model.Name,
                Price = Model.Price,                
            };

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var product = _ProductData.GetProductById(id);
            if (product is null)
                return NotFound();

            return View(new ProductViewModel
            {
                Id = product.Id,                
                Name = product.Name,
                Price = product.Price,
                Brand = product.Brand.Name,
                Section = product.Section.Name,
                ImageUrl = product.ImageUrl,
            });
        }
    }
}
