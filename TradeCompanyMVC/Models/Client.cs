using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace TradeCompanyMVC.Models
{
    public class Client
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название клиента
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Время создания
        /// </summary>
        public DateTime CreatedAt { get; set; }


        /// <summary>
        /// Заказы клиента
        /// </summary>
        public virtual List<Order> Orders { get; set; }
    }
}
