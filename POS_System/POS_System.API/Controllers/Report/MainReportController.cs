using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS_System.Domains.Admin;
using POS_System.Domains.Report;
using POS_System.Domains.Selling;
using POS_System.Repositories.Interfaces.Identity;
using POS_System.Repositories.Interfaces.Report;
using POS_System.Repositories.Interfaces.Selling;
using POS_System.ViewModels.Admin;

namespace POS_System.API.Controllers.Identity
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainReportController : ControllerBase
    {

        private readonly IMainReportInterface _mainReportInterface;

        public MainReportController(IMainReportInterface mainReportInterface)
        {
            _mainReportInterface = mainReportInterface;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var listofMainReports = await _mainReportInterface.GetMainReportsAsync();

            var json = JsonConvert.SerializeObject(listofMainReports, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

            return Ok(json);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddMainReport(MainReport mainReport)
        {
            var res = await _mainReportInterface.AddMainReportAsync(mainReport);
            return Ok(res);
        }

        [HttpPut]


        [Route("update")]
        public async Task<IActionResult> UpdateMainReport(MainReport mainReport)
        {
            mainReport = await _mainReportInterface.UpdateMainReportAsync(mainReport);
            return Ok(mainReport);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> DeleteMainReport(Guid id)
        {
            await _mainReportInterface.DeleteMainReportAsync(id);
            return Ok();
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> GetMainReport(Guid id)
        {
            await _mainReportInterface.GetMainReportAsync(id);
            return Ok();
        }

    }
}
