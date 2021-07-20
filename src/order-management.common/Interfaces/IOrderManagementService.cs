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
        Task<IEnumerable<Order>> Get();

        Task<IEnumerable<Order>> Get(string fio);

        Task<Order> Create(Order order);

        Task<IEnumerable<string>> Remove(IEnumerable<string> id);
    }
}
