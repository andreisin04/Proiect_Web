using PizzaTimeApp.Entities;
using PizzaTimeApp.Models;
using PizzaTimeApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Managers
{
    public class ProductsManager : IProductsManager
    {
        private readonly IProductsRepository productsRepository;

        public ProductsManager(IProductsRepository repository)
        {
            this.productsRepository = repository;
        }

        public void Create(ProductModel model)
        {
            var newProduct = new Product
            {
                Id = model.Id,
                CategoryId = model.CategoryId,
                Product_Name = model.Product_Name,
                Price = model.Price
            };

            productsRepository.Create(newProduct);
        }

        public void Update(ProductModel productModel)
        {
            var product = GetProductById(productModel.Id);

            product.Product_Name = productModel.Product_Name;
            product.Price = productModel.Price;
            product.CategoryId = productModel.CategoryId;

            productsRepository.Update(product);
        }

        public void Delete(string id)
        {
            var product = GetProductById(id);

            productsRepository.Delete(product);
        }

        public Product GetProductById(string id)
        {
            var product = productsRepository.GetProducts()
                .FirstOrDefault(x => x.Id == id);

            return product;
        }

        public List<Product> GetProducts()
        {
            return productsRepository.GetProducts().ToList();
        }

        public List<Product> GetProductsFiltered()
        {
            var products = productsRepository.GetProductsWithCategory();
            var productsFiltered = products.Where(x => x.OrderProduct.Count > 0).ToList();

            return productsFiltered;
        }

        public List<ProductFirstOrderModel> GetProductsOrdered()
        {
            var productsOrdered = productsRepository.GetProductsWithCategory()
                .Where(x => x.OrderProduct.Count > 0)
                .Select(x => new ProductFirstOrderModel { Id = x.Id, Category_Name = x.Category.Name })
                .OrderByDescending(x => x.Category_Name)
                .ToList();

            return productsOrdered;
        }

        public List<string> GetProductsIds()
        {
            var products = productsRepository.GetProducts();
            var idList = products.Select(x => x.Id).ToList();

            return idList;
        }

        public List<Product> GetProductsWithCategory()
        {
            var productsWithCategory = productsRepository.GetProductsWithCategory().ToList();
            return productsWithCategory;
        } 
    }
}
