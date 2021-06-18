
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using WebStore.Domain;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Mapping;
using WebStore.Models;
using WebStore.Services.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Services.InCookies
{
    public class InCookiesCartService : ICartService
    {
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly IProductData _ProductData;
        private readonly string _CartName;
        public InCookiesCartService(IHttpContextAccessor HttpContextAccessor, IProductData ProductData)
        {
            _HttpContextAccessor = HttpContextAccessor;
            _ProductData = ProductData;

            var user = HttpContextAccessor.HttpContext!.User;
            var user_name = user.Identity!.IsAuthenticated ? $"-{user.Identity.Name}" : null;
            _CartName = $"WebStore.Cart{user_name}";
        }

        public void Add(int id)
        {
        }

        public void Decrement(int id)
        {
        }

        public void Remove(int id)
        {            
        }

        public void Clear()
        {            
        }

        public CartViewModel GetViewModel()
        {            
        }
    }
}
