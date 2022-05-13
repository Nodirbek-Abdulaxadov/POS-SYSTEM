using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS_System.Domains.Admin;
using POS_System.Domains.Inventory;
using POS_System.Domains.Selling;
using POS_System.Repositories.Interfaces.Identity;
using POS_System.Repositories.Interfaces.Inventory;
using POS_System.Repositories.Interfaces.Selling;
using POS_System.ViewModels.Admin;
using POS_System.ViewModels.Selling;

namespace POS_System.API.Controllers.Identity
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {

        private readonly ISupplierInterface _supplierInterface;

        public SupplierController(ISupplierInterface supplierInterface)
        {
            _supplierInterface = supplierInterface;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var listofSuppliers = await _supplierInterface.GetSuppliersAsync();

            var json = JsonConvert.SerializeObject(listofSuppliers, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

            return Ok(json);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddSupplier(AddSupplierViewModel viewModel)
        {
            var res = await _supplierInterface.AddSupplierAsync((Supplier)viewModel);
            return Ok(res);
        }

        [HttpPut]


        [Route("update")]
        public async Task<IActionResult> UpdateSupplier(Supplier supplier)
        {
            supplier = await _supplierInterface.UpdateSupplier(supplier);
            return Ok(supplier);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> DeleteSupplier(Guid id)
        {
            await _supplierInterface.DeleteSupplierAsync(id);
            return Ok();
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> GetSupplier(Guid id)
        {
            await _supplierInterface.GetSupplierAsync(id);
            return Ok();
        }

    }
}

