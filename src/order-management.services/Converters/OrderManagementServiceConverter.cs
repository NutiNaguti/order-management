using System;
using System.Linq;
using System.Collections.Generic;
using order_management.common.Models;

namespace order_management.services.converters
{ 
    public static class OrderManagementServiceConverter
    {
        public static Order MapToModel(this repository.Models.Order order)
        {
            if (order == null)
            {
                return new Order();
            }

            var result = new Order
            {
                Id = order.Id,
                DateTime = order.DateTime,
                FIO = order.FIO,
                Description = order.Description,
                Cost = order.Cost
            };
            
            return result;
        }
        
        public static repository.Models.Order MapToModel(this Order order)
        {
            if (order == null)
            {
                return new repository.Models.Order();
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
                return new List<Order>();
            }

            var result = ordersList.Select(x => new Order()
            {
                Id = x.Id,
                Cost = x.Cost,
                FIO = x.FIO,
                Description = x.Description,
                DateTime = x.DateTime
            });

            return result.ToList();
        }
    }
}
