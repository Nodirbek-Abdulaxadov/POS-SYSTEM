using Microsoft.AspNetCore.Mvc;
using POS_System.BL.Interfaces;
using POS_System.Domains.Selling;
using POS_System.Repositories.Interfaces.Selling;

namespace POS_System.API.Controllers.Report
{
    [ApiController,Route("api/[controller]")]
    public class ProductReportController: ControllerBase
    {
        private readonly IProductReportInterface reportInterface;
        private readonly IProductInterface product;

        public ProductReportController(IProductReportInterface reportInterface,
                                        IProductInterface product)
        {
            this.reportInterface = reportInterface;
            this.product = product;
        }
        [HttpGet, Route("getallreport/{productName}")]
        public async Task<IActionResult> AllReport(string productName)
        {
            if (!(await ProductExist(productName)))
            {
                return BadRequest();
            }
            
            return Ok(await reportInterface.ProductAllReport(productName));
        }
        [HttpGet, Route("todaysreport")]
        public async Task<IActionResult> TodaysReport(string productName)
        {
            if (!(await ProductExist(productName)))
            {
                return BadRequest();
            }
            return Ok(await reportInterface.ProductTodaysReport(productName));
        }

        [NonAction]
        private async Task<bool> ProductExist(string name)
        {
            var list = await product.GetProductsAsync();
            return list.Any(p => p.Name == name);
        }
    }
}
