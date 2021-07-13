using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using order_management.common.Interfaces;
using order_management.common.Models;
using order_management.repository.Interfaces;
using order_management.services.converters;

namespace order_management.services
{
    public class OrderManagementService : IOrderManagementService
    {
        private readonly IOrderContext _orderContext;

        public OrderManagementService(IOrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public async Task AddNewOrder(Order order)
        {
            await _orderContext.AddNewOrder(order.MapToModel());
        }

        public async Task Remove(long id)
        {
            await _orderContext.Remove(id);
        }

        public Task<IEnumerable<Order>> GetAllOrders()
        {
            var result = _orderContext.GetAllOrders().ToList();
            return (Task<IEnumerable<Order>>)result.MapToModel();
        }

        public async Task<IEnumerable<Order>> GetOrdersByFio(string fio)
        {
            var result = await _orderContext.GetOrdersByFio(fio);
            return result.MapToModel();
        }
    }
}
