using PizzaTimeApp.Entities;
using PizzaTimeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Managers
{
    public interface IOrdersManager
    {
        List<Order> GetOrders();
        Order GetOrderById(string id);
        void Create(OrderModel orderModel);
        void Update(OrderModel orderModel);
        void Delete(string id);
    }
}
