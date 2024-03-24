using TradeCompanyApp.DAL.Models;
using TradeCompanyApp.Domain.Models;

namespace TradeCompanyApp.DAL.Converters
{
    public static class ConvertService
    {
        public static Client ToClient(ClientDto clientDto)
        {
            return new Client()
            {
                Id = clientDto.Id,
                Name = clientDto.Name,
                Email = clientDto.Email,
                Description = clientDto.Description,
                CreatedAt = clientDto.CreatedAt,
            };
        }

        public static ClientDto? ToClientDto(Client? client)
        {
            if (client == null)
                return null;

            return new ClientDto()
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Description = client.Description,
                CreatedAt = client.CreatedAt,
                Orders = client?.Orders?.Select(x => ToOrderPure(x)).ToList()
            };
        }


        public static Order? ToOrder(OrderDto? order)
        {
            if (order == null)
                return null;

            return new Order()
            {
                OrderId = order.OrderId,
                Description = order.Description,
                Address = order.Address,
                ClientId = order.ClientId,
            };
        }


        public static OrderDto? ToOrderDto(Order? order)
        {
            if (order == null)
                return null;

            return new OrderDto()
            {
                OrderId = order.OrderId,
                Description = order.Description,
                Address = order.Address,
                ClientId = order.ClientId,
                Client = ToClientDto(order.Client)
            };
        }

        public static OrderDto? ToOrderPure(Order? order)
        {
            if (order == null)
                return null;

            return new OrderDto()
            {
                OrderId = order.OrderId,
                Description = order.Description,
                Address = order.Address,
                ClientId = order.ClientId,
            };
        }


    }
}
