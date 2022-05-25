using Microsoft.AspNetCore.Mvc;
using POS_System.BL.Extensions;
using POS_System.BL.Interfaces;

namespace POS_System.API.Controllers.Report
{
    [ApiController]
    [Route("api/allreport")]
    public class AllReportController : ControllerBase
    {
        private readonly ISellingReportInterface sellingReport;

        public AllReportController(ISellingReportInterface sellingReport)
        {
            this.sellingReport = sellingReport;
        }

        //barcha hisoboti
        [HttpGet("getall")]
        public async Task<IActionResult> Get()
        {
            var json = await sellingReport.AllSellingReport();

            return Ok(json);
        }

        [HttpGet("get")]
        public IActionResult Get(string startDate, string endDate)
        {
            DateOperations dateOperations = new DateOperations();
            if (dateOperations.IsLater(startDate, endDate))
            {
                return BadRequest();
            }

            return Ok(sellingReport.AllSellingReport(DateTime.Parse(startDate), DateTime.Parse(endDate)));
        }
    }
}
