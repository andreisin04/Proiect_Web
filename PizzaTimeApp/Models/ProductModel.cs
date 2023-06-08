using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Models
{
    public class ProductModel
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string Product_Name { get; set; }
        public int Price { get; set; }
    }
}
