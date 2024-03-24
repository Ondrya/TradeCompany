using Microsoft.EntityFrameworkCore;
using TradeCompanyApp.DAL.Data;
using TradeCompanyApp.Models;
using TradeCompanyApp.ModelsDto;

namespace TradeCompanyApp.Services
{
    /// <summary>
    /// Класс доступа к данным
    /// </summary>
    public class DataService
    {
        /// <summary>
        /// Контекст работы с базой данных
        /// </summary>
        private readonly string _cn;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="cn"></param>
        public DataService(string cn)
        {
            _cn = cn;
        }


        public TradeCompanyAppContext GetContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TradeCompanyAppContext>();
            optionsBuilder.UseSqlServer(_cn);
            return new TradeCompanyAppContext(optionsBuilder.Options);
        }


        #region Client

        /// <summary>
        /// Создать нового клиента
        /// </summary>
        /// <param name="clientDto"></param>
        public void Create(ClientDto clientDto)
        {
            var client = ConvertService.ToClient(clientDto);

            using (var _context = GetContext())
            {
                _context.Client.Add(client);
                _context.SaveChanges();
            }
        }


        /// <summary>
        /// Обновить клиента
        /// </summary>
        /// <param name="clientDto"></param>
        public void Update(ClientDto clientDto)
        {
            var client = ConvertService.ToClient(clientDto);

            using (var _context = GetContext())
            {
                _context.Attach(client).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Удалить клиента
        /// </summary>
        /// <param name="clientDtoId"></param>
        public void ClientRemove(int clientDtoId)
        {
            using (var _context = GetContext())
            {
                var client = _context.Client.Find(clientDtoId);

                if (client != null)
                {
                    _context.Client.Remove(client);
                    _context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Проверить существование клиента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ClientExists(int id)
        {
            using (var _context = GetContext())
            {
                return (_context.Client?.Any(e => e.Id == id)).GetValueOrDefault();
            }
        }


        /// <summary>
        /// Найти клиента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClientDto? ClientFind(int? id)
        {
            if (id == null)
                return null;

            using (var _context = GetContext())
            {
                var res = _context.Client.FirstOrDefault(m => m.Id == id);
                return res == null ? null : ConvertService.ToClientDto(res);
            }
        }

        /// <summary>
        /// Получить данные клиента с информацией о заказах
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClientDto? ClientGet(int? id)
        {
            if (id == null)
                return null;

            using (var _context = GetContext())
            {
                var client = _context
                .Client
                .Where(m => m.Id == id)
                .Include(x => x.Orders)
                .FirstOrDefault();

                return ConvertService.ToClientDto(client);
            }
        }

        /// <summary>
        /// Получить всех клиентов
        /// </summary>
        /// <returns></returns>
        public List<ClientDto?> ClientGetAll()
        {
            using (var _context = GetContext())
            {
                return _context
                .Client
                //.Include(x => x.Orders)
                .Select(x => ConvertService.ToClientDto(x))
                .ToList();
            }
        }

        #endregion


        #region Order

        /// <summary>
        /// Создать новый заказ
        /// </summary>
        /// <param name="orderDto"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Create(OrderDto orderDto)
        {
            var order = ConvertService.ToOrder(orderDto);

            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            using (var _context = GetContext())
            {
                _context.Order.Add(order);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Обновить заказ
        /// </summary>
        /// <param name="orderDto"></param>
        public void Update(OrderDto orderDto)
        {
            var order = ConvertService.ToOrder(orderDto);

            using (var _context = GetContext())
            {
                _context.Attach(order).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }


        /// <summary>
        /// Удалить заказ
        /// </summary>
        /// <param name="orderId"></param>
        public void OrderRemove(int? orderId)
        {
            using (var _context = GetContext())
            {
                var order = _context.Order.Find(orderId);

                if (order != null)
                {
                    _context.Order.Remove(order);
                    _context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Проверить сущствование заказа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool OrderExists(int id)
        {
            using (var _context = GetContext())
            {
                return (_context.Order?.Any(e => e.OrderId == id)).GetValueOrDefault();
            }
        }


        /// <summary>
        /// Найти заказ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderDto? OrderFind(int? id)
        {
            if (id == null)
                return null;

            using (var _context = GetContext())
            {
                var res = _context.Order.FirstOrDefault(m => m.OrderId == id);
                return res == null ? null : ConvertService.ToOrderDto(res);
            }
        }

        /// <summary>
        /// Получить информацию о заказе с информацией о клиенте
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderDto? OrderGet(int? id)
        {
            if (id == null)
                return null;

            using (var _context = GetContext())
            {
                var order = _context
                .Order
                .Where(m => m.OrderId == id)
                .Include(x => x.Client)
                .FirstOrDefault();

                return ConvertService.ToOrderDto(order);
            }
        }

        /// <summary>
        /// Список всех заказов
        /// </summary>
        /// <returns></returns>
        public IList<OrderDto?> OrderGetAll()
        {
            using (var _context = GetContext())
            {
                return _context
                .Order
                .Include(o => o.Client)
                .Select(x => ConvertService.ToOrderDto(x))
                .ToList();
            }
        }

        #endregion

    }
}
