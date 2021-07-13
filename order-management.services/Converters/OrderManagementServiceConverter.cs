using System;
using System.Linq;
using System.Collections.Generic;
using order_management.common.Models;

namespace order_management.services.converters
{ 
    public static class OrderManagementServiceConverter
    {
        public static repository.Models.Order MapToModel(this Order order)
        {
            if (order == null)
            {
                return null;
            }

            var result = new repository.Models.Order()
            {
                Id = order.Id,
                Cost = order.Cost,
                FIO = order.FIO,
                Description = order.Description,
                DateTime = order.DateTime
            };

            return result;
        }

        public static IEnumerable<Order> MapToModel(this IEnumerable<repository.Models.Order> orders)
        {
            var ordersList = orders?.ToList();
            if (ordersList == null || ordersList.Count == 0)
            {
                return null;
            }

            var result = ordersList.Select(x => new Order()
            {
                Id = x.Id,
                Cost = x.Cost,
                FIO = x.FIO,
                Description = x.Description,
                DateTime = x.DateTime
            });

            return result;
        }
    }
}
