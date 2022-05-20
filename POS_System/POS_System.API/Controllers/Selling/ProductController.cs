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
    public class ProductController : ControllerBase
    {

        private readonly IProductInterface _productInterface;

        public ProductController(IProductInterface productInterface)
        {
            _productInterface = productInterface;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var listofProducts = await _productInterface.GetProductsAsync();

            var json = JsonConvert.SerializeObject(listofProducts, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

            return Ok(json);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddProduct(AddProductViewModel product)
        {
            var res = await _productInterface.AddProductAsync((Product)product);
            return Ok(res);
        }

        [HttpPut]


        [Route("update")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            product = await _productInterface.UpdateProductAsync(product);
            return Ok(product);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _productInterface.DeleteProductAsync(id);
            return Ok();
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> Getproduct(Guid id)
        {
            await _productInterface.GetProductAsync(id);
            return Ok();
        }

    }
}

