using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnsClient.Internal;
using Microsoft.Extensions.Logging;
using order_management.common.Interfaces;
using order_management.common.Models;
using order_management.repository.Interfaces;
using order_management.services.converters;
using ILogger = DnsClient.Internal.ILogger;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace order_management.services.Services
{
    public class OrderManagementService : IOrderManagementService
    {
        private readonly IOrderContext _orderContext;
        private readonly ILogger<OrderManagementService> _logger;

        public OrderManagementService(IOrderContext orderContext, ILogger<OrderManagementService> logger)
        {
            _logger = logger;
            _orderContext = orderContext;
        }

        public async Task<Order> Create(Order order)
        {
            try
            {
                var dateTime = DateTime.Now;
                order.DateTime = new DateTime(dateTime.Year, dateTime.Month,
                    dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
                var result = await _orderContext.Create(order.MapToModel());
                return result.MapToModel();
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message, e.Data);
                return new Order();
            }
        }

        public async Task<IEnumerable<string>> Remove(IEnumerable<string> id)
        {
            try
            {
                var result = await _orderContext.Remove(id);
                return result;
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message, e.Data);
                return new List<string>();
            }
        }

        public async Task<IEnumerable<Order>> Get()
        {
            try
            {
                var result = await _orderContext.Get();
                return result.MapToModel();
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message, e.Data);
                return new List<Order>();
            }
        }

        public async Task<IEnumerable<Order>> Get(string fio)
        {
            try
            {
                var result = await _orderContext.Get(fio);
                return result.MapToModel();
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message, e.Data);
                return new List<Order>();
            }
        }
    }
}
