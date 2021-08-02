﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebStore.Domain;
using WebStore.Infrastructure.Mapping;
using WebStore.Services.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class CatalogController : Controller
    {
        private const string __PageSizeConfigName = "CatalogPageSize";

        private readonly IProductData _ProductData;

        private readonly IConfiguration _Configuration;

        public CatalogController(IProductData ProductData, IConfiguration Configuration)
        {
            _ProductData = ProductData;
            _Configuration = Configuration;
        }

        public IActionResult Index(int? BrandId, int? SectionId, int Page = 1, int? PageSize = null)
        {
            var page_size = PageSize ?? _Configuration.GetValue(__PageSizeConfigName, 6);

            var filter = new ProductFilter
            {
                BrandId = BrandId,
                SectionId = SectionId,
                Page = Page,
                PageSize = page_size
            };

            var (products, total_count) = _ProductData.GetProducts(filter);

            return View(new CatalogViewModel
            {
                BrandId = BrandId,
                SectionId = SectionId,
                Products = products.OrderBy(p => p.Order).ToView(),
                PageViewModel = new Domain.ViewModels.PageViewModel
                {
                    Page = Page,
                    PageSize = page_size,
                    TotalItems = total_count,
                }
            });
        }

        public IActionResult Details(int Id)
        {
            var product = _ProductData.GetProductById(Id);
            if (product is null)
                return NotFound();

            return View(product.ToView());           
        }

        public IActionResult GetFeaturesItems(int? BrandId, int? SectionId, int Page = 1, int? PageSize = null) =>
            PartialView("Paetial/_Products", GetProducts(BrandId, SectionId, Page, PageSize));

        private IEnumerable<ProductViewModel> GetProducts(int? BrandId, int? SectionId, int Page, int? PageSize) =>
            _ProductData.GetProducts(new ProductFilter
            {
                BrandId = BrandId,
                SectionId = SectionId,
                Page = Page,
                PageSize = PageSize ?? _Configuration.GetValue(__PageSizeConfigName, 6),
            }).Products.OrderBy(p => p.Order).ToView();
        
    }
}