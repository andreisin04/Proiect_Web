using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Entities
{
    public class Product
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string Product_Name { get; set; }
        public int Price { get; set; }
        
        public virtual ProductDetails ProductDetails { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
        
    }
}
