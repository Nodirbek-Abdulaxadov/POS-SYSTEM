using Microsoft.AspNetCore.Mvc;
using POS_System.BL.Interfaces;
using POS_System.Domains.Selling;

namespace POS_System.API.Controllers.Report
{
    [ApiController,Route("api/[controller]")]
    public class ProductReportController: ControllerBase
    {
        private readonly IProductReportInterface reportInterface;

        public ProductReportController(IProductReportInterface reportInterface)
        {
            this.reportInterface = reportInterface;
        }
        [HttpGet, Route("getallreport")]
        public async Task<IActionResult> ProductAllReport(string productName)
        {
            Product product = new Product();
            if(productName != product.Name)
            {
                return BadRequest();
            }
            return Ok(await reportInterface.ProductAllReport(productName));
        }
        [HttpGet, Route("todaysreport")]
        public async Task<IActionResult> TodaysReport(string productName)
        {

        }
    }
}
