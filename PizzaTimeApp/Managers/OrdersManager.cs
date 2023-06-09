using PizzaTimeApp.Entities;
using PizzaTimeApp.Models;
using PizzaTimeApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Managers
{
    public class OrdersManager : IOrdersManager
    {
        private readonly IOrdersRepository ordersRepository;

        public OrdersManager(IOrdersRepository repository)
        {
            this.ordersRepository = repository;
        }
        public List<Order> GetOrders()
        {
            return ordersRepository.GetOrders().ToList();
        }

        public void Create(OrderModel orderModel)
        {
            var newOrder = new Order
            {
                Id = orderModel.Id,
                OrderDate = orderModel.OrderDate,
                UserId = orderModel.UserId
            };

            ordersRepository.Create(newOrder);
        }

        public void Update(OrderModel orderModel)
        {
            var order = GetOrderById(orderModel.Id);

            order.OrderDate = orderModel.OrderDate;
            order.UserId = orderModel.UserId;

            ordersRepository.Update(order);
        }

        public void Delete(string id)
        {
            var order = GetOrderById(id);

            ordersRepository.Delete(order);
        }

        public Order GetOrderById(string id)
        {
            var order = ordersRepository.GetOrders()
                .FirstOrDefault(x => x.Id == id);

            return order;
        }
    }
}
