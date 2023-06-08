using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Entities
{
    public class Order
    {
        public string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
