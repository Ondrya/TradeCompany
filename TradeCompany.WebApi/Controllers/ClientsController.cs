using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TradeCompanyApp.DAL.Converters;
using TradeCompanyApp.Domain.Interfaces;
using TradeCompanyApp.Domain.Models;

namespace TradeCompany.WebApi.Controllers
{
    /// <summary>
    /// Контроллер клиентской информации
    /// </summary>
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion(1)]
    [ApiVersion(2)]
    public class ClientsController : ControllerBase
    {
        /// <summary>
        /// Провайдер данных
        /// </summary>
        private readonly IDataService _service;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service"></param>
        public ClientsController(IDataService service)
        {
            _service = service;
        }


        /// <summary>
        /// Получить список всех клиентов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<ClientDto>> Get()
        {
            var clients = _service.ClientGetAll();
            return Ok(clients);
        }


        /// <summary>
        /// Получить клиента по его идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ClientDto> Get(int id)
        {
            var client = _service.ClientFind(id);
            if (client == null)
             return NotFound();
            return Ok(client);
        }


        /// <summary>
        /// Добавить нового клиента
        /// </summary>
        /// <param name="clientCreate"></param>
        /// <returns>id клиента</returns>
        [HttpPost]
        public ActionResult<int> Post(ClientCreateDto clientCreate)
        {
            var clients = _service.ClientGetAll().Select(x => x.Email).ToList();
            if (clients.Contains(clientCreate.Email))
                return BadRequest("Клиент с таким email уже существует");
            var client = ConvertService.ToClientDto(clientCreate);
            var clientId = _service.ClientCreate(client);
            return Ok(clientId);
        }


        /// <summary>
        /// Обновить запись клиента
        /// </summary>
        /// <param name="id"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Put(int id, ClientDto client)
        {
            if (id != client.Id)
                return BadRequest();
            _service.ClientUpdate(client);
            return Ok();
        }


        /// <summary>
        /// Удалить клиента
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var client = _service.ClientFind(id);
            if (client == null)
                return NotFound();
            _service.ClientRemove(id);
            return Ok(client);
        }
    }
}
