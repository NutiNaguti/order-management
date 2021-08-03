using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace order_management.common.Models
{
    public record Order
    {
        /// <summary>
        /// ID заказа
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        [JsonProperty("dateTime")]
        public DateTime DateTime { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>
        [Required]
        [JsonProperty("fio")]
        public string FIO { get; set; }
        /// <summary>
        /// Описание заказа
        /// </summary>
        [Required]
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// Стоимость
        /// </summary>
        [Required]
        [JsonProperty("cost")]
        public decimal Cost { get; set; }
    }
}
