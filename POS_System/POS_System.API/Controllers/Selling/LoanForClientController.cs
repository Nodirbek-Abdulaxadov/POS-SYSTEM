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
    public class LoanForClientController : ControllerBase
    {

        private readonly ILoanForClientInterface _loanForClientInterface;

        public LoanForClientController(ILoanForClientInterface loanForClientInterface)
        {
            _loanForClientInterface = loanForClientInterface;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var listofLoanForclients = await _loanForClientInterface.GetLoanForClientsAsync();

            var json = JsonConvert.SerializeObject(listofLoanForclients, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

            return Ok(json);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddLoanForClient(LoanForClient loanForClient)
        {
            var res = await _loanForClientInterface.AddLoanForClientAsync(loanForClient);
            return Ok(res);
        }

        [HttpPut]


        [Route("update")]
        public async Task<IActionResult> UpdateLoanForClient(LoanForClient loanForClient)
        {
            loanForClient = await _loanForClientInterface.UpdateLoanForClientAsync(loanForClient);
            return Ok(loanForClient);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> DeleteLoanForClient(Guid id)
        {
            await _loanForClientInterface.DeleteLoanForClientAsync(id);
            return Ok();
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> GetloanForClient(Guid id)
        {
            await _loanForClientInterface.GetLoanForClientAsync(id);
            return Ok();
        }

    }
}

