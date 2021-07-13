using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using order_management.common.Interfaces;
using order_management.common.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace order_management.Controllers
{
    [Route("api/[controller]")]
    public class OrderManagementController : Controller
    {
        private readonly IOrderManagementService _orderManagementService;

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            var result = await _orderManagementService.GetAllOrders();
            return result;
        }

        // GET api/values/5
        [HttpGet("{fio}")]
        public async Task<IEnumerable<Order>> GetOrdersByFio(string fio)
        {
            var result = await _orderManagementService.GetOrdersByFio(fio);
            return result;
        }

        // POST api/values
        [HttpPost]
        public async void AddNewOrder([FromBody] Order order)
        {
            await _orderManagementService.AddNewOrder(order);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(string id)
        {
            await _orderManagementService.Remove(id);
        }
    }
}
