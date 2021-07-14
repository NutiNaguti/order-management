using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using order_management.repository.Interfaces;
using order_management.repository.Models;
using order_management.common.Common;

namespace order_management.repository
{
    /// <summary>
    /// Контекст БД
    /// </summary>
    public class OrderContext : IOrderContext
    {
        private readonly IMongoCollection<Order> _collection;

        public OrderContext(IOrderManagementDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Order>(settings.OrderCollectionName);
        }

        /// <inheritdoc/>
        public IEnumerable<Order> Get() =>
            _collection.Find(x => true).ToEnumerable();

        /// <inheritdoc/>
        public IEnumerable<Order> Get(string fio) =>
            _collection.Find(x => x.FIO == fio).ToEnumerable();

        /// <inheritdoc/>   
        public void Create(Order order) =>
            _collection.InsertOne(order);

        /// <inheritdoc/>
        public void Remove(string id) =>
            _collection.DeleteOne(x => x.Id == id);
    }
}
