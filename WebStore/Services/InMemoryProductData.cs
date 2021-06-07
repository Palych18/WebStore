using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Domain.Entities;
using WebStore.Services.Interfaces;

namespace WebStore.Services
{
    public class InMemoryProductData : IProductData
    {
        IEnumerable<Brand> IProductData.GetBrands()
        {
            return (IEnumerable<Brand>)TestData.Brands;
        }

        IEnumerable<Section> IProductData.GetSections()
        {
            return (IEnumerable<Section>)TestData.Sections;
        }
    }
}
