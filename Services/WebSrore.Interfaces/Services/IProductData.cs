using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain;
using WebStore.Domain.Entities;

namespace WebStore.Services.Interfaces
{
    public interface IProductData
    {
        IEnumerable<Section> GetSections();

        Section GetSection(int id);

        IEnumerable<Brand> GetBrands();

        Brand GetBrand(int id);

        IEnumerable<Product> GetProducts(ProductFilter Filter = null);

        Product GetProductById(int Id);
    }
}
