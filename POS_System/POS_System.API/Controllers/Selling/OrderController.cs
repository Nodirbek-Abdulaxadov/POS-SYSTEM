using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS_System.BL.Extensions;
using POS_System.Domains.Pagination;
using POS_System.Domains.Selling;
using POS_System.Repositories.Interfaces.Selling;

namespace POS_System.API.Controllers.Identity
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly IOrderInterface _orderInterface;

        public OrderController(IOrderInterface orderInterface)
        {
            _orderInterface = orderInterface;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var listofOrders = await _orderInterface.GetOrdersAsync();

            var json = JsonConvert.SerializeObject(listofOrders, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

            return Ok(json);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] QueryStringParameters parameters)
        {
            var listofOrders = await _orderInterface.GetOrders(parameters);

            var metaData = new
            {
                listofOrders.TotalCount,
                listofOrders.PageSize,
                listofOrders.CurrentPage,
                listofOrders.HasNext,
                listofOrders.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));

            var json = JsonConvert.SerializeObject(listofOrders, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

            return Ok(json);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddOrder(Order order)
        {
            Date date1 = new Date(DateTime.Now);
            order.Date = date1.ToStringDate(date1, '/');

            var res = await _orderInterface.AddOrderAsync(order);
            return Ok(res);


        }

        [HttpPut]


        [Route("update")]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            order = await _orderInterface.UpdateOrderAsync(order);
            return Ok(order);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            await _orderInterface.DeleteOrderAsync(id);
            return Ok();
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            await _orderInterface.GetOrderAsync(id);
            return Ok();
        }

    }
}

