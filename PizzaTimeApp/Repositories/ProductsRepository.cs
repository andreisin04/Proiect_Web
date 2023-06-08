using Microsoft.EntityFrameworkCore;
using PizzaTimeApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private PizzaTimeContext db;

        public ProductsRepository (PizzaTimeContext db)
        {
            this.db = db;
        }

        public IQueryable<Product> GetProducts()
        {
            var products = db.Products;

            return products;
        }

        public IQueryable<Product> GetProductsWithCategory()
        {
            var productsJoin = db.Products
                .Include(x => x.Category)
                .Include(x => x.OrderProduct);

            return productsJoin;
        }

        public void Create(Product product)
        {
            db.Products.Add(product);

            db.SaveChanges();
        }

        public void Update(Product product)
        {
            db.Products.Update(product);

            db.SaveChanges();
        }

        public void Delete(Product product)
        {
            db.Products.Remove(product);

            db.SaveChanges();
        }
    }
}
