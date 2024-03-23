using System.ComponentModel;

namespace TradeCompanyApp.DAL.Models
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
        [DisplayName("Название")]
        public string Name { get; set; }

        /// <summary>
        /// email
        /// </summary>
        [DisplayName("Email")]
        public string? Email { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [DisplayName("Описание")]
        public string? Description { get; set; }

        /// <summary>
        /// Время создания
        /// </summary>
        [DisplayName("Создан")]
        public DateTime CreatedAt { get; set; }


        /// <summary>
        /// Заказы клиента
        /// </summary>
        public virtual List<Order>? Orders { get; set; }


        public override string ToString()
        {
            return $"{Name} - (id: {Id})";
        }
    }
}
