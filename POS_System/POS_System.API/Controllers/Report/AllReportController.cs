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


        [HttpGet("getall")]
        public IActionResult Get()
        {
            return Ok(sellingReport.AllSellingReport());
        }

        [HttpGet("get")]
        public IActionResult Get(string startDate, string endDate)
        {
            DateOperations dateOperations = new DateOperations();
            if (dateOperations.IsLater(startDate, endDate))
            {
                return BadRequest();
            }

            return Ok(sellingReport.AllSellingReport(startDate, endDate));
        }
    }
}
