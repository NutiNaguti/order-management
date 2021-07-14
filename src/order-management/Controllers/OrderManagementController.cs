using System.Collections.Generic;
using System.Linq;
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
        public ActionResult<IEnumerable<Order>> Get() =>
             _orderManagementService.Get().ToList();

        [HttpGet("{fio}")]
        public ActionResult<IEnumerable<Order>> Get(string fio)
        {
            var result = _orderManagementService.Get(fio).ToList();
            if (result == null || result.Count == 0)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            _orderManagementService.Create(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAsync(string id)
        {
            _orderManagementService.Remove(id);
            return NoContent();
        }
    }
}
