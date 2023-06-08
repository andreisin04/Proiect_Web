using PizzaTimeApp.Entities;
using PizzaTimeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Managers
{
    public interface IDetailsManager
    {
        List<ProductDetails> GetAllDetails();
        List<string> GetProductDetails(string productId);
        ProductDetails GetDetailsById(string id);
        void Create(DetailsModel details);
        void Update(DetailsModel detailsModel);
        void Delete(string id);
    }
}
