using System.ComponentModel;
using System.Runtime.Serialization;

namespace TradeCompanyApp.Domain.Models
{
    [DataContract]
    public class OrderDto
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        [DataMember]
        public int OrderId { get; set; }

        /// <summary>
        /// Описание заказа
        /// </summary>
        [DataMember]
        [DisplayName("Описание")]
        public string Description { get; set; }

        /// <summary>
        /// Адрес заказа
        /// </summary>
        [DataMember]
        [DisplayName("Адрес")]
        public string Address { get; set; }


        /// <summary>
        /// Идентификатор клиента в заказе
        /// </summary>
        [DataMember]
        [DisplayName("Клиент")]
        public int ClientId { get; set; }

        /// <summary>
        /// Клиент в заказе
        /// </summary>
        [DataMember]
        [DisplayName("Клиент")]
        public virtual ClientDto Client { get; set; }
    }
}
