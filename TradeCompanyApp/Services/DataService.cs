using Microsoft.EntityFrameworkCore;
using TradeCompanyApp.DAL.Data;
using TradeCompanyApp.Models;
using TradeCompanyApp.ModelsDto;

namespace TradeCompanyApp.Services
{
    public class DataService
    {
        public DataService(string cn)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TradeCompanyAppContext>();
            optionsBuilder.UseSqlServer(cn);
            _context = new TradeCompanyAppContext(optionsBuilder.Options);
        }


        private DAL.Data.TradeCompanyAppContext _context;


        public void Create(ClientDto clientDto)
        {
            var client = ConvertService.ToClient(clientDto);
            _context.Client.Add(client);
            _context.SaveChanges();
        }

        public void Create(OrderDto orderDto)
        {
            var order = ConvertService.ToOrder(orderDto);

            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            _context.Order.Add(order);
            _context.SaveChanges();
        }

        public void ClientRemove(int clientDtoId)
        {
            var client = _context.Client.Find(clientDtoId);

            if (client != null)
            {
                _context.Client.Remove(client);
                _context.SaveChanges();
            }
        }


        public void OrderRemove(int? orderId)
        {
            var order = _context.Order.Find(orderId);

            if (order != null)
            {
                _context.Order.Remove(order);
                _context.SaveChanges();
            }
        }


        public ClientDto? ClientFind(int? id)
        {
            if (id == null) return null;
            var res = _context.Client.FirstOrDefault(m => m.Id == id);
            return res == null ? null : ConvertService.ToClientDto(res);
        }


        public ClientDto? ClientGet(int? id)
        {
            if (id == null)
                return null;

            var client = _context
                .Client
                .Where(m => m.Id == id)
                .Include(x => x.Orders)
                .FirstOrDefault();

            return ConvertService.ToClientDto(client);
        }


        public ClientDto ClientGetPlain(int? id)
        {
            if (id == null)
                return null;

            var client = _context
                .Client
                .Where(m => m.Id == id)
                .Include(x => x.Orders)
                .FirstOrDefault();

            return ConvertService.ToClientDtoPlain(client);
        }


        public List<ClientDto> ClientGetAll()
        {
            return _context.Client.Select(x => ConvertService.ToClientDto(x)).ToList();
        }

        public OrderDto? OrderFind(int? id)
        {
            if (id == null)
                return null;
            var res = _context.Order.FirstOrDefault(m => m.OrderId == id);
            return res == null ? null : ConvertService.ToOrderDto(res);
        }

        public OrderDto OrderGet(int? id)
        {
            if (id == null)
                return null;
            
            var order = _context
                .Order
                .Where(m => m.OrderId == id)
                .Include(x => x.Client)
                .FirstOrDefault();

            return ConvertService.ToOrderDto(order);
        }

        public IList<OrderDto> OrderGetAll()
        {
            return _context
                .Order
                .Include(o => o.Client)
                .Select(x => ConvertService.ToOrderDto(x))
                .ToList();
        }


        public void Update(ClientDto clientDto)
        {
            var client = ConvertService.ToClient(clientDto);
            _context.Attach(client).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool ClientExists(int id)
        {
            return (_context.Client?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public bool OrderExists(int id)
        {
            return (_context.Order?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }

        public void Update(OrderDto orderDto)
        {
            var order = ConvertService.ToOrder(orderDto);
            _context.Attach(order).State = EntityState.Modified;
            _context.SaveChanges();
        }

        
    }
}
