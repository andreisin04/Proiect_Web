using PizzaTimeApp.Entities;
using PizzaTimeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Managers
{
    public interface IProductsManager
    {
        List<Product> GetProducts();
        List<string> GetProductsIds();
        List<Product> GetProductsWithCategory();
        List<Product> GetProductsFiltered();
        Product GetProductById(string id);
        List<ProductFirstOrderModel> GetProductsOrdered();
        void Create(ProductModel model);
        void Update(ProductModel model);
        void Delete(string id);
    }
}
