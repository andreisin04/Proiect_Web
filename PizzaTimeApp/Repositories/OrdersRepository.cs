using PizzaTimeApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly PizzaTimeContext db;

        public OrdersRepository(PizzaTimeContext db)
        {
            this.db = db;
        }

        public IQueryable<Order> GetOrders()
        {
            var orders = db.Orders;

            return orders;
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);

            db.SaveChanges();
        }

        public void Update(Order order)
        {
            db.Orders.Update(order);

            db.SaveChanges();
        }
        public void Delete(Order order)
        {
            db.Orders.Remove(order);

            db.SaveChanges();
        }
    }
}
