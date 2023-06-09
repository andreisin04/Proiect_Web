using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Models
{
    public class OrderModel
    {
        public string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
    }
}
