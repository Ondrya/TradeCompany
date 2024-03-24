using TradeCompanyApp.Domain.Models;

namespace TradeCompanyApp.Domain.Interfaces
{
    /// <summary>
    /// Доступ к данным CRM
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Проверить существование клиента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool ClientExists(int id);

        /// <summary>
        /// Найти клиента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ClientDto? ClientFind(int? id);

        /// <summary>
        /// Получить данные клиента с информацией о заказах
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ClientDto? ClientGet(int? id);

        /// <summary>
        /// Получить всех клиентов
        /// </summary>
        /// <returns></returns>
        List<ClientDto?> ClientGetAll();

        /// <summary>
        /// Удалить клиента
        /// </summary>
        /// <param name="clientDtoId"></param>
        void ClientRemove(int clientDtoId);

        /// <summary>
        /// Создать нового клиента
        /// </summary>
        /// <param name="clientDto"></param>
        void Create(ClientDto clientDto);

        /// <summary>
        /// Создать новый заказ
        /// </summary>
        /// <param name="orderDto"></param>
        /// <exception cref="ArgumentNullException"></exception>
        void Create(OrderDto orderDto);

        /// <summary>
        /// Проверить сущствование заказа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool OrderExists(int id);

        /// <summary>
        /// Найти заказ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OrderDto? OrderFind(int? id);

        /// <summary>
        /// Получить информацию о заказе с информацией о клиенте
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OrderDto? OrderGet(int? id);

        /// <summary>
        /// Список всех заказов
        /// </summary>
        /// <returns></returns>
        IList<OrderDto?> OrderGetAll();

        /// <summary>
        /// Удалить заказ
        /// </summary>
        /// <param name="orderId"></param>
        void OrderRemove(int? orderId);

        /// <summary>
        /// Обновить клиента
        /// </summary>
        /// <param name="clientDto"></param>
        void Update(ClientDto clientDto);

        /// <summary>
        /// Обновить заказ
        /// </summary>
        /// <param name="orderDto"></param>
        void Update(OrderDto orderDto);
    }

}