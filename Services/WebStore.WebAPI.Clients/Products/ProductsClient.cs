using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebSrore.Interfaces;
using WebStore.Domain;
using WebStore.Domain.Entities;
using WebStore.Services.Interfaces;
using WebStore.WebAPI.Clients.Base;

namespace WebStore.WebAPI.Clients.Products
{
    public class ProductsClient : BaseClient, IProductData
    {
        public ProductsClient(HttpClient Client) : base(Client, WebAPIAddress.Products) { }

        Brand IProductData.GetBrand(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Brand> IProductData.GetBrands()
        {
            throw new NotImplementedException();
        }

        Product IProductData.GetProductById(int Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Product> IProductData.GetProducts(ProductFilter Filter)
        {
            throw new NotImplementedException();
        }

        Section IProductData.GetSection(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Section> IProductData.GetSections()
        {
            throw new NotImplementedException();
        }
    }
}
