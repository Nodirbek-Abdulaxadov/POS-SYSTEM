using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS_System.Domains.Admin;
using POS_System.Domains.Inventory;
using POS_System.Domains.Selling;
using POS_System.Repositories.Interfaces.Identity;
using POS_System.Repositories.Interfaces.Inventory;
using POS_System.Repositories.Interfaces.Selling;
using POS_System.ViewModels.Admin;

namespace POS_System.API.Controllers.Identity
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionProccessController : ControllerBase
    {

        private readonly ITransactionProccessInterface _transactionProccessInterface;

        public TransactionProccessController(ITransactionProccessInterface transactionProccessInterface)
        {
            _transactionProccessInterface = transactionProccessInterface;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var listofAllTransactionProccess = await _transactionProccessInterface.GetAllTransactionProccessAsync();

            var json = JsonConvert.SerializeObject(listofAllTransactionProccess, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

            return Ok(json);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddTransacctionProccess(TransactionProccess transactionProccess)
        {
            var res = await _transactionProccessInterface.AddTransactionProccessAsync(transactionProccess);
            return Ok(res);
        }

        [HttpPut]


        [Route("update")]
        public async Task<IActionResult> UpdateTrasactionProccess(TransactionProccess transactionProccess)
        {
            transactionProccess = await _transactionProccessInterface.UpdateTransactionProccessAsync(transactionProccess);
            return Ok(transactionProccess);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> DeletetransactionProccess(Guid id)
        {
            await _transactionProccessInterface.DeleteTransactionProccessAsync(id);
            return Ok();
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> GetTransaction(Guid id)
        {
            await _transactionProccessInterface.GetTransactionProccessAsync(id);
            return Ok();
        }

    }
}

