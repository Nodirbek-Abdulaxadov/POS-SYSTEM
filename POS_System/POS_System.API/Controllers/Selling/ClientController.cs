using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS_System.Domains.Admin;
using POS_System.Domains.Selling;
using POS_System.Repositories.Interfaces.Identity;
using POS_System.Repositories.Interfaces.Selling;
using POS_System.ViewModels.Admin;

namespace POS_System.API.Controllers.Identity
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {

        private readonly IClientInterface _clientInterface;

        public ClientController(IClientInterface clientInterface)
        {
            _clientInterface = clientInterface;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var listofClients = await _clientInterface.GetClientsAsync();

            var json = JsonConvert.SerializeObject(listofClients, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

            return Ok(json);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddClient(Client client)
        {
            var res = await _clientInterface.AddClientAsync(client);
            return Ok(res);


        }

        [HttpPut]


        [Route("update")]
        public async Task<IActionResult> UpdateClient(Client client)
        {
            client = await _clientInterface.UpdateClientAsync(client);
            return Ok(client);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            await _clientInterface.DeleteClientAsync(id);
            return Ok();
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> GetClient(Guid id)
        {
            await _clientInterface.GetClientAsync(id);
            return Ok();
        }

    }
}

