using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaTimeApp.Entities;
using PizzaTimeApp.Managers;
using PizzaTimeApp.Models;
using PizzaTimeApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsManager manager;

        public ProductController(IProductsManager productsManager)
        {
            this.manager = productsManager;
        }

        [HttpGet("")]
        //[Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetProducts()
        {
            var products = manager.GetProducts();

            return Ok(products);
        }

        [HttpGet("select")]
        public async Task<IActionResult> GetProductsIds()
        {
            var productsIds = manager.GetProductsIds();

            return Ok(productsIds);
        }

        [HttpGet("eager-join")] //eager Loading 
        public async Task<IActionResult> JoinEager()
        {
            var products = manager.GetProductsWithCategory();

            return Ok(products);
        }

        [HttpGet("filter")] //produse comandate cel putin odata cu prima comanda ce il contine 
        public async Task<IActionResult> Filter()
        {
            var products = manager.GetProductsFiltered();
            
            return Ok(products);
        }

        [HttpGet("orderby")]
        public async Task<IActionResult> OrderBy()
        {
            var products = manager.GetProductsOrdered();

            return Ok(products);
        }

        [HttpPost("post")]
        public async Task<IActionResult> Create([FromBody] ProductModel productModel)
        {
            manager.Create(productModel);

            return Ok();
        }

        [HttpPut("")]
        public async Task<IActionResult> Update([FromBody] ProductModel productModel)
        {
            manager.Update(productModel);

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