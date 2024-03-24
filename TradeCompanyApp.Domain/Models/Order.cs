using System.ComponentModel;

namespace TradeCompanyApp.Domain.Models
{
    public class OrderDto
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Описание заказа
        /// </summary>
        [DisplayName("Описание")]
        public string Description { get; set; }

        /// <summary>
        /// Адрес заказа
        /// </summary>
        [DisplayName("Адрес")]
        public string Address { get; set; }


        /// <summary>
        /// Идентификатор клиента в заказе
        /// </summary>
        [DisplayName("Клиент")]
        public int ClientId { get; set; }

        /// <summary>
        /// Клиент в заказе
        /// </summary>
        [DisplayName("Клиент")]
        public virtual ClientDto? Client { get; set; }
    }
}
