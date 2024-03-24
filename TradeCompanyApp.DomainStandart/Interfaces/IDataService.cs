using System.Collections.Generic;
using System.ServiceModel;
using TradeCompanyApp.Domain.Models;

namespace TradeCompanyApp.Domain.Interfaces
{
    /// <summary>
    /// Доступ к данным CRM
    /// </summary>
    [ServiceContract]
    public interface IDataService
    {
        /// <summary>
        /// Проверить существование клиента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        bool ClientExists(int id);

        /// <summary>
        /// Найти клиента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        ClientDto ClientFind(int? id);

        /// <summary>
        /// Получить данные клиента с информацией о заказах
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        ClientDto ClientGet(int? id);

        /// <summary>
        /// Получить всех клиентов
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<ClientDto> ClientGetAll();

        /// <summary>
        /// Удалить клиента
        /// </summary>
        /// <param name="clientDtoId"></param>
        [OperationContract]
        void ClientRemove(int clientDtoId);

        /// <summary>
        /// Создать нового клиента
        /// </summary>
        /// <param name="clientDto"></param>
        [OperationContract]
        void ClientCreate(ClientDto clientDto);

        /// <summary>
        /// Создать новый заказ
        /// </summary>
        /// <param name="orderDto"></param>
        /// <exception cref="ArgumentNullException"></exception>
        [OperationContract]
        void OrderCreate(OrderDto orderDto);

        /// <summary>
        /// Проверить сущствование заказа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract] 
        bool OrderExists(int id);

        /// <summary>
        /// Найти заказ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract] 
        OrderDto OrderFind(int? id);

        /// <summary>
        /// Получить информацию о заказе с информацией о клиенте
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract] 
        OrderDto OrderGet(int? id);

        /// <summary>
        /// Список всех заказов
        /// </summary>
        /// <returns></returns>
        [OperationContract] 
        IList<OrderDto> OrderGetAll();

        /// <summary>
        /// Удалить заказ
        /// </summary>
        /// <param name="orderId"></param>
        [OperationContract] 
        void OrderRemove(int? orderId);

        /// <summary>
        /// Обновить клиента
        /// </summary>
        /// <param name="clientDto"></param>
        [OperationContract] 
        void ClientUpdate(ClientDto clientDto);

        /// <summary>
        /// Обновить заказ
        /// </summary>
        /// <param name="orderDto"></param>
        [OperationContract] 
        void OrderUpdate(OrderDto orderDto);
    }

}