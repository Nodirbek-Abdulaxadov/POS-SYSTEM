using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS_System.Domains.Inventory;
using POS_System.Repositories.Interfaces.Inventory;
using POS_System.ViewModels.Inventory;

namespace POS_System.API.Controllers.Inventory
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanForInventoryController : ControllerBase
    {
        private readonly ILoanForInventoryInterface _loanForInventoryInterface;

        public LoanForInventoryController(ILoanForInventoryInterface loanForInventoryInterface )
        {
            _loanForInventoryInterface = loanForInventoryInterface;
        }
    
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var listOfLoanForInventory = await _loanForInventoryInterface.GetLoanForInventorysAsync();

            var json = JsonConvert.SerializeObject(listOfLoanForInventory, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

            return Ok(json);
        }

        [HttpPost]
        [Route("add")]

        public async Task<IActionResult> AddLoanForInventoryAsync(AddLoanForInventoryViewModel loanForInventory)
        {

            var res = await _loanForInventoryInterface.AddLoanForInventoryAsync((LoanForInventory)loanForInventory);
            return Ok(res);

        }

        [HttpPut, Route("update")]

        public async Task<IActionResult> UpdateLoanForInventoryAsync(LoanForInventory loanForInventory)
        {
            loanForInventory = await _loanForInventoryInterface.UpdateLoanForInventoryAsync(loanForInventory);
                return Ok(loanForInventory);
        }
        
        [HttpDelete, Route("delete/{id}")]

        public async Task<IActionResult> DeleteLoanForInventoryAsync(Guid id)
        {
            await _loanForInventoryInterface.DeleteLoanForInventoryAsync(id);
                return Ok();

        }

        [HttpGet, Route("get/{id}")]

        public async Task<IActionResult> GetLoanForInventoryAsync(Guid id)
        {
            await _loanForInventoryInterface.GetLoanForInventoryAsync(id);
            return Ok();

        }


    }

}
