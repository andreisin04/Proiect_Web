using Microsoft.EntityFrameworkCore;
using PizzaTimeApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Repositories
{
    public class DetailsRepository : IDetailsRepository
    {
        private PizzaTimeContext db;

        public DetailsRepository(PizzaTimeContext db)
        {
            this.db = db;
        }

        public IQueryable<ProductDetails> GetAllDetails()
        {
            var details = db.ProductDetails;

            return details;
        }

        public IQueryable<string> GetProductDetails(string productId)
        {
            var details = db.ProductDetails
                            .Include(x => x.Product)
                            .Where(x => x.Id == productId)
                            .Select(x => x.Ingredients);

            return details;
        }

        public void Create(ProductDetails details)
        {
            db.ProductDetails.Add(details);

            db.SaveChanges();
        }

        public void Update(ProductDetails details)
        {
            db.ProductDetails.Update(details);

            db.SaveChanges();
        }

        public void Delete(ProductDetails details)
        {
            db.ProductDetails.Remove(details);

            db.SaveChanges();
        }
    }
}
