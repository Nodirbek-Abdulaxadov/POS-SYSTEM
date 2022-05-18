using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS_System.Domains.Admin;
using POS_System.Domains.Selling;
using POS_System.Repositories.Interfaces.Identity;
using POS_System.Repositories.Interfaces.Selling;
using POS_System.ViewModels.Admin;
using POS_System.ViewModels.Selling;

namespace POS_System.API.Controllers.Identity
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellingProccessController : ControllerBase
    {

        private readonly ISellingProccessInterface _sellingProccessInterface;

        public SellingProccessController(ISellingProccessInterface sellingProccessInterface)
        {
            _sellingProccessInterface = sellingProccessInterface;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var listofAllSellingProccess = await _sellingProccessInterface.GetAllSellingProccessAsync();

            var json = JsonConvert.SerializeObject(listofAllSellingProccess, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

            return Ok(json);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddSellingProccess(AddSellingProccessViewModel sellingProccess)
        {
            var res = await _sellingProccessInterface.AddSellingProccessAsync((SellingProccess)sellingProccess);
            return Ok(res);


        }

        [HttpPut]


        [Route("update")]
        public async Task<IActionResult> UpdateSellingProccess(SellingProccess sellingProccess)
        {
            sellingProccess = await _sellingProccessInterface.UpdateSellingProccessAsync(sellingProccess);
            return Ok(sellingProccess);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> DeletesellingProccess(Guid id)
        {
            await _sellingProccessInterface.DeeleteSellingProccessAsync(id);
            return Ok();
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> GetSellingProccess(Guid id)
        {
            await _sellingProccessInterface.GetSellingProccessAsync(id);
            return Ok();
        }

    }
}

