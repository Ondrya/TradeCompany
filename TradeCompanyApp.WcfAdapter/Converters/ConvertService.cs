using TradeCompanyApp.Domain.Models;
using ClientWcf = DataServiceWCF.ClientDto;
using OrderWcf = DataServiceWCF.OrderDto;

namespace TradeCompanyApp.WcfAdapter.Converters
{
    public static class ConvertService
    {
        public static ClientWcf ToClientWcf(this ClientDto clientDto)
        {
            return new ClientWcf()
            {
                Id = clientDto.Id,
                Name = clientDto.Name,
                Email = clientDto.Email,
                Description = clientDto.Description,
                CreatedAt = clientDto.CreatedAt,
            };
        }

        public static ClientDto? ToClientDto(this ClientWcf? client)
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


        public static OrderWcf? ToOrderWcf(this OrderDto? order)
        {
            if (order == null)
                return null;

            return new OrderWcf()
            {
                OrderId = order.OrderId,
                Description = order.Description,
                Address = order.Address,
                ClientId = order.ClientId,
            };
        }


        public static OrderDto? ToOrderDto(this OrderWcf? order)
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

        public static OrderDto? ToOrderPure(this OrderWcf? order)
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
