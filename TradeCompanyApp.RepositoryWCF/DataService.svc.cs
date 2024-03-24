using System;
using System.Collections.Generic;
using TradeCompanyApp.Domain.Interfaces;
using TradeCompanyApp.Domain.Models;

namespace TradeCompanyApp.RepositoryWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DataService.svc or DataService.svc.cs at the Solution Explorer and start debugging.
    public class DataService : IDataService
    {
        public bool ClientExists(int id)
        {
            throw new NotImplementedException();
        }

        public ClientDto ClientFind(int? id)
        {
            throw new NotImplementedException();
        }

        public ClientDto ClientGet(int? id)
        {
            throw new NotImplementedException();
        }

        public List<ClientDto> ClientGetAll()
        {
            throw new NotImplementedException();
        }

        public void ClientRemove(int clientDtoId)
        {
            throw new NotImplementedException();
        }

        public void ClientCreate(ClientDto clientDto)
        {
            throw new NotImplementedException();
        }

        public void OrderCreate(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public bool OrderExists(int id)
        {
            throw new NotImplementedException();
        }

        public OrderDto OrderFind(int? id)
        {
            throw new NotImplementedException();
        }

        public OrderDto OrderGet(int? id)
        {
            throw new NotImplementedException();
        }

        public IList<OrderDto> OrderGetAll()
        {
            throw new NotImplementedException();
        }

        public void OrderRemove(int? orderId)
        {
            throw new NotImplementedException();
        }

        public void ClientUpdate(ClientDto clientDto)
        {
            throw new NotImplementedException();
        }

        public void OrderUpdate(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }
    }
}
