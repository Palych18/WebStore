using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Identity.Orders;
using WebStore.ViewModels;

namespace WebStore.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetUserOrders(string UserName);

        Task<Order> GetOrderById(int Id);

        Task<Order> CreateOrder(string UserName, CartViewModel Cart, OrderViewModel OrderModel);


    }
}