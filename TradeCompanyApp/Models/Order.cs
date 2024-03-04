namespace TradeCompanyApp.Models
{
    public class Order
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Описание заказа
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Адрес заказа
        /// </summary>
        public string Address { get; set; }


        /// <summary>
        /// Идентификатор клиента в заказе
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Клиент в заказе
        /// </summary>
        public virtual Client? Client { get; set; }
    }
}
