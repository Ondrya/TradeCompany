using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TradeCompanyApp.Domain.Models
{
    [DataContract]
    public class ClientDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Название клиента
        /// </summary>
        [DataMember]
        [DisplayName("Название")]
        public string Name { get; set; }

        /// <summary>
        /// email
        /// </summary>
        [DataMember]
        [DisplayName("Email")]
        public string Email { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [DataMember]
        [DisplayName("Описание")]
        public string Description { get; set; }

        /// <summary>
        /// Время создания
        /// </summary>
        [DataMember]
        [DisplayName("Создан")]
        public DateTime CreatedAt { get; set; }


        /// <summary>
        /// Заказы клиента
        /// </summary>
        [DataMember]
        public virtual List<OrderDto> Orders { get; set; }


        public override string ToString()
        {
            return $"{Name} - (id: {Id})";
        }
    }
}
