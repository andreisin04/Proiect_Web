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
    public class OrderController : ControllerBase
    {
        private readonly IOrdersManager manager;

        public OrderController(IOrdersManager ordersManager)
        {
            this.manager = ordersManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = manager.GetOrders();

            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderModel orderModel)
        {
            manager.Create(orderModel);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] OrderModel orderModel)
        {
            manager.Update(orderModel);

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
