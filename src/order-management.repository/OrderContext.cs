using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using order_management.repository.Interfaces;
using order_management.repository.Models;
using Options = order_management.common.Options;

namespace order_management.repository
{
    /// <summary>
    /// Контекст БД
    /// </summary>
    public class OrderContext : IOrderContext
    {
        private readonly IMongoDatabase _database;
        private readonly Options _options;

        public OrderContext(IOptions<Options> options)
        {
            _options = options.Value;

            var connectionString = _options.ConnectionString;
            var connection = new MongoUrlBuilder(connectionString);
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(connection.DatabaseName);
        }

        public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Orders");

        /// <inheritdoc/>
        public IEnumerable<Order> GetAllOrders() => Orders.AsQueryable();

        /// <inheritdoc/>
        public async Task<IEnumerable<Order>> GetOrdersByFio(string fio)
        {
            var builder = new FilterDefinitionBuilder<Order>();
            var filter = builder.Empty;

            if (!string.IsNullOrWhiteSpace(fio))
            {
                filter &= builder.Regex("Fio", new BsonRegularExpression(fio));
            }

            return await Orders.Find(filter).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task AddNewOrder(Order order) => await Orders.InsertOneAsync(order);

        /// <inheritdoc/>
        public async Task Remove(long id) => await Orders.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id.ToString())));
    }
}
