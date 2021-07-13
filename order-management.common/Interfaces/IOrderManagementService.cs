using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using order_management.common.Models;

namespace order_management.common.Interfaces
{
    /// <summary>
    /// Интерфейс доступа к методам сервиса
    /// </summary>
    public interface IOrderManagementService
    {
        Task<IEnumerable<Order>> GetAllOrders();

        Task<IEnumerable<Order>> GetOrdersByFio(string fio);

        Task AddNewOrder(Order order);

        Task Remove(long id);
    }
}
