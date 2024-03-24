using System;
using System.Collections.Generic;
using System.Linq;
using TradeCompanyApp.Domain.Interfaces;
using TradeCompanyApp.Domain.Models;

namespace TradeCompanyApp.RepositoryWCF
{
    public class DataServiceWCF : IDataService
    {
        private readonly string _cn;

        public DataServiceWCF()
        {
            _cn = Properties.Resources.ConnectionString;
        }

        public DataServiceWCF(string cn = null)
        {
            _cn = cn ?? Properties.Resources.ConnectionString;
        }

        public DataDataContext GetContext()
        {
            return new DataDataContext(_cn);
        }


        #region Client

        public void ClientCreate(ClientDto clientDto)
        {
            var client = ConvertService.ToClient(clientDto);

            using (var _context = GetContext())
            {
                _context.Clients.InsertOnSubmit(client);
                _context.SubmitChanges();
            }
        }

        public void ClientUpdate(ClientDto clientDto)
        {
            using (var _context = GetContext())
            {
                var client = _context.Clients.Single(x => x.Id == clientDto.Id);
                client.Name = clientDto.Name;
                client.Description = clientDto.Description;
                _context.SubmitChanges();
            }
        }

        public void ClientRemove(int clientDtoId)
        {
            using (var _context = GetContext())
            {
                var client = _context.Clients.Single(x => x.Id == clientDtoId);

                if (client != null)
                {
                    _context.Clients.DeleteOnSubmit(client);
                    _context.SubmitChanges();
                }
            }
        }

        public bool ClientExists(int id)
        {
            using (var _context = GetContext())
            {
                return (_context.Clients?.Any(e => e.Id == id)).GetValueOrDefault();
            }
        }

        public ClientDto ClientFind(int? id)
        {
            if (id == null)
                return null;

            using (var _context = GetContext())
            {
                var res = _context.Clients.FirstOrDefault(m => m.Id == id);
                return res == null ? null : ConvertService.ToClientDto(res);
            }
        }

        public ClientDto ClientGet(int? id)
        {
            if (id == null)
                return null;

            using (var _context = GetContext())
            {
                var client = _context
                .Clients
                .Where(m => m.Id == id)
                .FirstOrDefault();

                return ConvertService.ToClientDto(client);
            }
        }

        public List<ClientDto> ClientGetAll()
        {
            using (var _context = GetContext())
            {
                return _context
                .Clients
                .Select(x => ConvertService.ToClientDto(x))
                .ToList();
            }
        }

        #endregion


        #region Order

        public void OrderCreate(OrderDto orderDto)
        {
            var order = ConvertService.ToOrder(orderDto);

            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            using (var _context = GetContext())
            {
                _context.Orders.InsertOnSubmit(order);
                _context.SubmitChanges();
            }
        }

        public void OrderUpdate(OrderDto orderDto)
        {
            using (var _context = GetContext())
            {
                var order = _context.Orders.Single(x => x.OrderId == orderDto.OrderId);
                order.Address = orderDto.Address;
                order.Description = orderDto.Description;
                _context.SubmitChanges();
            }
        }

        public void OrderRemove(int? orderId)
        {
            using (var _context = GetContext())
            {
                var order = _context.Orders.Single(x => x.OrderId == orderId);

                if (order != null)
                {
                    _context.Orders.DeleteOnSubmit(order);
                    _context.SubmitChanges();
                }
            }
        }

        public bool OrderExists(int id)
        {
            using (var _context = GetContext())
            {
                return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
            }
        }

        public OrderDto OrderFind(int? id)
        {
            if (id == null)
                return null;

            using (var _context = GetContext())
            {
                var res = _context.Orders.FirstOrDefault(m => m.OrderId == id);
                return res == null ? null : ConvertService.ToOrderDto(res);
            }
        }

        public OrderDto OrderGet(int? id)
        {
            if (id == null)
                return null;

            using (var _context = GetContext())
            {
                var order = _context
                .Orders
                .Where(m => m.OrderId == id)
                .FirstOrDefault();

                return ConvertService.ToOrderDto(order);
            }
        }

        public IList<OrderDto> OrderGetAll()
        {
            using (var _context = GetContext())
            {
                return _context
                .Orders
                .Select(x => ConvertService.ToOrderDto(x))
                .ToList();
            }
        }

        #endregion
    }
}
