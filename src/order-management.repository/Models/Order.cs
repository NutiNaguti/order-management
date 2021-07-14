using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace order_management.repository.Models
{
    /// <summary>
    /// Модель сущности БД
    /// </summary>
    public class Order
    {
        /// <summary>
        /// ID заказа
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime DateTime {get;set;}
        /// <summary>
        /// ФИО
        /// </summary>
        public string FIO { get; set; }
        /// <summary>
        /// Описание заказа
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Cost { get; set; }
    }
}
