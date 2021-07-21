using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using order_management.common.Interfaces;
using order_management.common.Models;

namespace order_management.Controllers
{
    [Route("api/[controller]")]
    public class OrderManagementController : Controller
    {
        private readonly IOrderManagementService _orderManagementService;

        public OrderManagementController(IOrderManagementService orderManagementService)
        {
            _orderManagementService = orderManagementService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            var orderList = await _orderManagementService.Get();
            return Ok(orderList);
        }

        [HttpGet("{fio}")]
        public async Task<ActionResult<IEnumerable<Order>>> Get([FromQuery] string fio)
        {
            var result = await _orderManagementService.Get(fio);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Order>> Create([FromBody] Order order)
        {
            var result = await _orderManagementService.Create(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<string>>> DeleteAsync([FromBody] string[] id)
        {
            var result = await _orderManagementService.Remove(id);
            return Ok(result);
        }
    }
}
