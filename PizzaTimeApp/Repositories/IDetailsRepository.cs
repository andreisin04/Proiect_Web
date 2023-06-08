using PizzaTimeApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Repositories
{
    public interface IDetailsRepository
    {
        IQueryable<ProductDetails> GetAllDetails();
        IQueryable<string> GetProductDetails(string productId);
        void Create(ProductDetails details);
        void Update(ProductDetails details);
        void Delete(ProductDetails details);
    }
}
