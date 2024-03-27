using DataServiceWCF;
using TradeCompanyApp.Domain.Models;

namespace TradeCompanyApp.DataClients
{
    public class DataServiceWCFProvider : Domain.Interfaces.IDataService
    {
        private readonly DataServiceClient _client;


        public DataServiceWCFProvider(DataServiceClient client) 
        {
            _client = client;   
        }

        public int ClientCreate(ClientDto clientDto)
        {
            var request = new ClientCreateRequest(clientDto);
            _client.ClientCreate(request);
        }

        public bool ClientExists(int id)
        {
            var request = new ClientExistsRequest(id);
            return _client.ClientExists(request).ClientExistsResult;
        }

        public ClientDto ClientFind(int? id)
        {
            var request = new ClientFindRequest(id);
            return _client.ClientFind(request).ClientFindResult;
        }

        public ClientDto ClientGet(int? id)
        {
            var request = new ClientGetRequest(id);
            return _client.ClientGet(request).ClientGetResult;
        }

        public List<ClientDto> ClientGetAll()
        {
            var request = new ClientGetAllRequest();
            return _client.ClientGetAll(request).ClientGetAllResult.ToList();
        }

        public void ClientRemove(int clientDtoId)
        {
            var request = new ClientRemoveRequest(clientDtoId);
            _client.ClientRemove(request);
        }

        public void ClientUpdate(ClientDto clientDto)
        {
            var request = new ClientUpdateRequest(clientDto);
            _client.ClientUpdate(request);
        }

        public void OrderCreate(OrderDto orderDto)
        {
            var request = new OrderCreateRequest(orderDto);
            _client.OrderCreate(request);
        }

        public bool OrderExists(int id)
        {
            var request = new OrderExistsRequest(id);
            return _client.OrderExists(request).OrderExistsResult;
        }

        public OrderDto OrderFind(int? id)
        {
            var request = new OrderFindRequest(id);
            return _client.OrderFind(request).OrderFindResult;
        }

        public OrderDto OrderGet(int? id)
        {
            var request = new OrderGetRequest(id);
            return _client.OrderGet(request).OrderGetResult;
        }

        public IList<OrderDto> OrderGetAll()
        {
            var request = new OrderGetAllRequest();
            return _client.OrderGetAll(request).OrderGetAllResult.ToList();
        }

        public void OrderRemove(int? orderId)
        {
            var request = new OrderRemoveRequest(orderId);
            _client.OrderRemove(request);
        }

        public void OrderUpdate(OrderDto orderDto)
        {
            var request = new OrderUpdateRequest(orderDto);
            _client.OrderUpdate(request);
        }
    }
}
