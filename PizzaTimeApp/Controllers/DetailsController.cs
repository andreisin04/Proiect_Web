using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaTimeApp.Entities;
using PizzaTimeApp.Managers;
using PizzaTimeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly IDetailsManager manager;

        public DetailsController(IDetailsManager detailsManager)
        {
            this.manager = detailsManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDetails()
        {
            var details = manager.GetAllDetails();

            return Ok(details);
        }

        [HttpGet("forProduct/{id}")]
        public async Task<IActionResult> GetDetails(string id) //detalii pentru produsul cu id-ul productId
        {
            var details = manager.GetProductDetails(id);

            return Ok(details);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DetailsModel detailsModel)
        {
            manager.Create(detailsModel);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DetailsModel detailsModel)
        {
            manager.Update(detailsModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            manager.Delete(id);

            return Ok();
        }
    }
}
