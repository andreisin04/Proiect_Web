using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Models
{
    public class DetailsModel
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string Ingredients { get; set; }
        public bool Spicy { get; set; }
    }
}
