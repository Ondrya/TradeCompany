using System.ComponentModel;
using System.Runtime.Serialization;

namespace TradeCompanyApp.Domain.Models
{
    /// <summary>
    /// Модель создания нового клиента
    /// </summary>
    [DataContract]
    public class ClientCreateDto
    {
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
    }
}
