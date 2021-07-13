using System;
using Newtonsoft.Json;

namespace order_management.common.Models
{
    public class Order
    {
        /// <summary>
        /// ID заказа
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        [JsonProperty("dateTime")]
        public DateTime DateTime { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>
        [JsonProperty("fio")]
        public string FIO { get; set; }
        /// <summary>
        /// Описание заказа
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// Стоимость
        /// </summary>
        [JsonProperty("cost")]
        public decimal Cost { get; set; }
    }
}
