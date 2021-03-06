using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;
using order_management.common.Common;
using order_management.repository.Interfaces;
using order_management.repository.Models;

namespace order_management.repository
{
    /// <summary>
    /// Контекст БД
    /// </summary>
    public class OrderContext : IOrderContext
    {
        private readonly ILogger<OrderContext> _logger;
        private readonly IMongoCollection<Order> _collection;

        public OrderContext(IOrderManagementDatabaseSettings settings, ILogger<OrderContext> logger)
        {
            _logger = logger;
            
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Order>(settings.OrderCollectionName);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Order>> Get()
        {
            var orderList = new List<Order>();
            try
            {
                orderList = await _collection.FindAsync(x => true).Result.ToListAsync();
                _logger.Log(LogLevel.Information ,"order list was founded");
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message, e.Data);
                return orderList;
            }

            return orderList;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Order>> Get(string fio)
        {
            try
            {
                var orderList = await _collection.FindAsync(x => x.FIO == fio);
                _logger.Log(LogLevel.Information, "order list was founded");
                return orderList.ToList();
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message, e.Data);
                return null;
            }
        }

        /// <inheritdoc/>   
        public async Task<Order> Create(Order order)
        {
            try
            {
                await _collection.InsertOneAsync(order);
                _logger.Log(LogLevel.Information, "order was been created in database");
                return order;
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message, e.Data);
                return null;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<string>> Remove(IEnumerable<string> idCollection)
        {
            try
            {
                var ids = idCollection.ToList();
                foreach (var id in ids)
                {
                    _logger.Log(LogLevel.Information, id);
                    var result = await _collection.DeleteOneAsync(x => x.Id == id);
                    _logger.Log(LogLevel.Information, $"{result.IsAcknowledged}");
                }
                return ids;
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message, e.Data);
                return null;
            }
        }
    }
}
