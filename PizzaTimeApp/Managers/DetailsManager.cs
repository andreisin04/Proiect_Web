using PizzaTimeApp.Entities;
using PizzaTimeApp.Models;
using PizzaTimeApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Managers
{
    public class DetailsManager : IDetailsManager
    {
        private readonly IDetailsRepository detailsRepository;
        public DetailsManager(IDetailsRepository repository)
        {
            this.detailsRepository = repository;
        }

        public List<ProductDetails> GetAllDetails()
        {
            return detailsRepository.GetAllDetails().ToList();
        }

        public List<string> GetProductDetails(string productId)
        {
            return detailsRepository.GetProductDetails(productId).ToList();
        }

        public void Create(DetailsModel detailsModel)
        {
            var newDetails = new ProductDetails
            {
                Id = detailsModel.Id,
                ProductId = detailsModel.ProductId,
                Ingredients = detailsModel.Ingredients,
                Spicy = detailsModel.Spicy
            };

            detailsRepository.Create(newDetails);
        }

        public void Update(DetailsModel detailsModel)
        {
            var details = GetDetailsById(detailsModel.Id);

            details.ProductId = detailsModel.ProductId;
            details.Ingredients = detailsModel.Ingredients;
            details.Spicy = detailsModel.Spicy;

            detailsRepository.Update(details);
        }

        public void Delete(string id)
        {
            var details = GetDetailsById(id);

            detailsRepository.Delete(details);
        }

        public ProductDetails GetDetailsById(string id)
        {
            var details = detailsRepository.GetAllDetails()
                .FirstOrDefault(x => x.Id == id);

            return details;
        }
    }
}
