using System.Collections.Generic;
using order_management.common.Models;

namespace order_management.common.Interfaces
{
    /// <summary>
    /// Интерфейс доступа к методам сервиса
    /// </summary>
    public interface IOrderManagementService
    {
        IEnumerable<Order> Get();

        IEnumerable<Order> Get(string fio);

        void Create(Order order);

        void Remove(string id);
    }
}
