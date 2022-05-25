using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public IActionResult Get()
        {
            var json = JsonConvert.SerializeObject(sellingReport.AllSellingReport(), Formatting.Indented,
                                                    new JsonSerializerSettings
                                                    {
                                                        ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                                                    });
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
