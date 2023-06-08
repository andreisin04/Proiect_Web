using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Entities
{
    public class ProductDetails
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string Ingredients { get; set; }
        public bool Spicy { get; set; }

        public virtual Product Product { get; set; }
    }
}
