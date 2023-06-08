using PizzaTimeApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Repositories
{
    public interface IProductsRepository
    {
        IQueryable<Product> GetProducts();
        IQueryable<Product> GetProductsWithCategory();
        void Create(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
