using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TradeCompanyApp.Domain.Interfaces;
using TradeCompanyApp.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TradeCompany.WebApi.Controllers
{
    /// <summary>
    /// Контроллер информации о заказах
    /// </summary>
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion(2)]
    public class OrdersController : ControllerBase
    {
        /// <summary>
        /// Провайдер данных
        /// </summary>
        private readonly IDataService _service;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service"></param>
        public OrdersController(IDataService service)
        {
            _service = service;
        }


        /// <summary>
        /// Получить список всех заказов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> Get()
        {
            var orders = _service.OrderGetAll();
            return Ok(orders);
        }

        
        /// <summary>
        /// Получить заказ по его номеру
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<OrderDto> Get(int id)
        {
            var order = _service.OrderFind(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }


        /// <summary>
        /// Получить список заказов клиента
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpGet("{clientId}")]
        public ActionResult<IEnumerable<OrderDto>> GetForClient(int clientId)
        {
            var client = _service.ClientGet(clientId);
            if (client == null)
                return NotFound("Клиент с таким идентификатором не найден");
            return Ok(client.Orders);
        }


        /// <summary>
        /// Добавиьт новый заказ
        /// </summary>
        /// <param name="order"></param>
        /// <returns>id заказа</returns>
        [HttpPost]
        public ActionResult<int> Post(OrderDto order)
        {
            var orderId = _service.OrderCreate(order);
            return Ok(orderId);
        }


        /// <summary>
        /// Обновить запись заказа
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Put(int id, OrderDto order)
        {
            if (id != order.OrderId)
                return BadRequest();
            _service.OrderUpdate(order);
            return Ok();
        }


        /// <summary>
        /// Удалить заказ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var order = _service.OrderFind(id);
            if (order == null)
                return NotFound();
            _service.OrderRemove(id);
            return Ok(order);
        }
    }
}
