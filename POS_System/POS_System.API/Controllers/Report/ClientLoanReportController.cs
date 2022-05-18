using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS_System.BL.Interfaces;

namespace POS_System.API.Controllers.Report
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientLoanReportController : ControllerBase
    {
        private readonly IClientLoanInterface loanInterface;

        public ClientLoanReportController(IClientLoanInterface loanInterface)
        {
            this.loanInterface = loanInterface;
        }
        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var res = await loanInterface.GetClientLoanReportAsync(id);

            return Ok(res);
        }
    }
}
