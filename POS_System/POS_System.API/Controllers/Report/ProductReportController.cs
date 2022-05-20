using Microsoft.AspNetCore.Mvc;
using POS_System.BL.Interfaces;
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

        //barcha hisoboti
        [HttpGet, Route("allreport/{productName}")]
        public async Task<IActionResult> ProductAllReport(string productName)
        {
            if (!(await ProductExist(productName)))
            {
                return BadRequest();
            }
            
            return Ok(await reportInterface.ProductAllReport(productName));
        }

        //bugunlik hisobot
        [HttpGet, Route("todaysreport/{productName}")]
        public async Task<IActionResult> ProductTodaysReport(string productName)
        {
            if (!(await ProductExist(productName)))
            {
                return BadRequest();
            }
            return Ok(await reportInterface.ProductTodaysReport(productName));
        }
        //kunlik hisobot
        [HttpGet,Route("dailyreport/")]
        public async Task<IActionResult> ProductDailyReport(string productName, string date)
        {
            if(!(await ProductExist(productName)))
            {
                return BadRequest();
            }
            return Ok(await reportInterface.ProductDailyReport(productName, date));
        }

        //oxirgi haftalik hisobot
        [HttpGet, Route("lastweeklreport/{productName}")]
        public async Task<IActionResult> ProductLastWeeklyReport(string productName)
        {
            if(!(await ProductExist(productName)))
            {
                return BadRequest();
            }
            return Ok(await reportInterface.ProductLastWeeklyReport(productName));
        }

        //oxirgi oylik hisobot
        [HttpGet, Route("lastmonthlreport/{productName}")]
        public async Task<IActionResult> ProductLastMonthlyReport(string productName)
        {
            if(!(await ProductExist(productName)))
            {
                return BadRequest();
            }
            return Ok(await reportInterface.ProductLastMonthlyReport(productName));
        }

        //oxirgi yillik hisobot
        [HttpGet, Route("lastyearlreport/{productName}")]
        public async Task<IActionResult> ProductLastYearlyReport(string productName)
        {
            if (!(await ProductExist(productName)))
            {
                return BadRequest();
            }
            return Ok(await reportInterface.ProductLastYearlyReport(productName));
        }

        //berilgan muddat oralig'idagi hisobot
        [HttpGet, Route("productreport")]
        public async Task<IActionResult> ProductReport(string productName, string startDate, string endDate)
        {
            if (!(await ProductExist(productName)))
            {
                return BadRequest();
            }
            return Ok(await reportInterface.ProductReport(productName, startDate, endDate));
        }
        //oxirgi N kunlik hisobot
        [HttpGet, Route("ndaysreport/{productName}/{N}")]
        public async Task<IActionResult> ProductLastNDaysReport(string productName, int N)
        {
            if (!(await ProductExist(productName)))
            {
                return BadRequest();
            }
            return Ok(await reportInterface.ProductLastNDaysReport(productName, N));
        }
        //oxirgi N haftalif hisobot
        [HttpGet, Route("nweeksreport/{productName}/{N}")]
        public async Task<IActionResult> ProductLastNWeeksReport(string productName, int N)
        {
            if (!(await ProductExist(productName)))
            {
                return BadRequest();
            }
            return Ok(await reportInterface.ProductLastNWeeksReport(productName, N));
        }
        //oxirgi N oylik hisobot
        [HttpGet, Route("nmonthsreport/{productName}/{N}")]
        public async Task<IActionResult> ProductLastNMonthsReport(string productName, int N)
        {
            if (!(await ProductExist(productName)))
            {
                return BadRequest();
            }
            return Ok(await reportInterface.ProductLastNMonthsReport(productName, N));
        }
        //oxirgi N yillik hisobot
        [HttpGet, Route("nyearsreport/{productName}/{N}")]
        public async Task<IActionResult> ProductLastNYearsReport(string productName, int N)
        {
            if (!(await ProductExist(productName)))
            {
                return BadRequest();
            }
            return Ok(await reportInterface.ProductLastNYearsReport(productName, N));
        }

        [NonAction]
        private async Task<bool> ProductExist(string name)
        {
            var list = await product.GetProductsAsync();
            return list.Any(p => p.Name == name);
        }
    }
}
