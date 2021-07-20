using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using order_management.repository.Models;

namespace order_management.repository.Interfaces
{
    public interface IOrderContext
    {
        /// <summary>
        /// Получить все заказы
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Order>> Get();

        /// <summary>
        /// Получить заказ по ФИО
        /// </summary>
        /// <param name="fio"></param>
        /// <returns></returns>
        Task<IEnumerable<Order>> Get(string fio);

        /// <summary>
        /// Добавить новый заказ
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<Order> Create(Order order);

        /// <summary>
        /// Удалить заказ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> Remove(IEnumerable<string> id);
    }
}
