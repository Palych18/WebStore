using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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

        public IEnumerable<Section> GetSections() => Get<IEnumerable<Section>>($"{Address}/section");

        public Section GetSection(int id) => Get<Section>($"{Address}/sections/{id}");

        public IEnumerable<Brand> GetBrands() => Get<IEnumerable<Brand>>($"{Address}/brand");

        public Brand GetBrand(int id) => Get<Brand>($"{Address}/brands/{id}");

        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            var response = Post(Address, Filter ?? new ProductFilter());
            var products = response.Content.ReadFromJsonAsync<IEnumerable<Product>>().Result;
            return products;
        }

        public Product GetProductById(int Id) => Get<Product>($"{Address}/{Id}");
    }
}
