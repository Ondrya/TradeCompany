using ClientDomain = TradeCompanyApp.Domain.Models.ClientDto;
using OrderDomain = TradeCompanyApp.Domain.Models.OrderDto;
using DataServiceWCF;
using TradeCompanyApp.WcfAdapter.Converters;

namespace TradeCompanyApp.DataClients
{
    public class DataServiceWCFProvider : TradeCompanyApp.Domain.Interfaces.IDataService
    {
        private readonly DataServiceClient _client;


        public DataServiceWCFProvider(DataServiceClient client) 
        {
            _client = client;   
        }

        public int ClientCreate(ClientDomain clientDto)
        {
            var request = new ClientCreateRequest(clientDto.ToClientWcf());
            var id = _client.ClientCreate(request).ClientCreateResult;
            return id;
        }

        public bool ClientExists(int id)
        {
            var request = new ClientExistsRequest(id);
            return _client.ClientExists(request).ClientExistsResult;
        }

        public ClientDomain ClientFind(int? id)
        {
            var request = new ClientFindRequest(id);
            return _client.ClientFind(request).ClientFindResult?.ToClientDto();
        }

        public ClientDomain ClientGet(int? id)
        {
            var request = new ClientGetRequest(id);
            return _client.ClientGet(request).ClientGetResult?.ToClientDto();
        }

        public List<ClientDomain> ClientGetAll()
        {
            var request = new ClientGetAllRequest();
            return _client.ClientGetAll(request).ClientGetAllResult
                .Select(x => x.ToClientDto())
                .ToList();
        }

        public void ClientRemove(int clientDtoId)
        {
            var request = new ClientRemoveRequest(clientDtoId);
            _client.ClientRemove(request);
        }

        public void ClientUpdate(ClientDomain clientDto)
        {
            var request = new ClientUpdateRequest(clientDto.ToClientWcf());
            _client.ClientUpdate(request);
        }

        public int OrderCreate(OrderDomain orderDto)
        {
            var request = new OrderCreateRequest(orderDto.ToOrderWcf());
            var id = _client.OrderCreate(request).OrderCreateResult;
            return id;
        }

        public bool OrderExists(int id)
        {
            var request = new OrderExistsRequest(id);
            return _client.OrderExists(request).OrderExistsResult;
        }

        public OrderDomain OrderFind(int? id)
        {
            var request = new OrderFindRequest(id);
            return _client.OrderFind(request).OrderFindResult?.ToOrderDto();
        }

        public OrderDomain OrderGet(int? id)
        {
            var request = new OrderGetRequest(id);
            return _client.OrderGet(request).OrderGetResult?.ToOrderDto();
        }

        public IList<OrderDomain> OrderGetAll()
        {
            var request = new OrderGetAllRequest();
            return _client.OrderGetAll(request).OrderGetAllResult
                .Select(x => x.ToOrderDto())
                .ToList();
        }

        public void OrderRemove(int? orderId)
        {
            var request = new OrderRemoveRequest(orderId);
            _client.OrderRemove(request);
        }

        public void OrderUpdate(OrderDomain orderDto)
        {
            var request = new OrderUpdateRequest(orderDto.ToOrderWcf());
            _client.OrderUpdate(request);
        }
    }
}
