using PizzaTimeApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Repositories
{
    public interface IOrdersRepository
    {
        IQueryable<Order> GetOrders();
        void Create(Order order);
        void Update(Order order);
        void Delete(Order order);
    }
}
