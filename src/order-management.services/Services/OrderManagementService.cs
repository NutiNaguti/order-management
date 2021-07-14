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

        public void Create(Order order)
        {
            _orderContext.Create(order.MapToModel());
        }

        public void Remove(string id)
        {
            _orderContext.Remove(id);
        }

        public IEnumerable<Order> Get()
        {
            var result = _orderContext.Get();
            return result.MapToModel();
        }

        public IEnumerable<Order> Get(string fio)
        {
            var result = _orderContext.Get(fio);
            return result.MapToModel();
        }
    }
}
