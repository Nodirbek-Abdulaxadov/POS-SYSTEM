using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS_System.Domains.Admin;
using POS_System.Domains.Inventory;
using POS_System.Domains.Selling;
using POS_System.Repositories.Interfaces.Identity;
using POS_System.Repositories.Interfaces.Inventory;
using POS_System.Repositories.Interfaces.Selling;
using POS_System.ViewModels.Admin;
using POS_System.ViewModels.Inventory;

namespace POS_System.API.Controllers.Identity
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {

        private readonly ITransactionInterface _transactionInterface;

        public TransactionController(ITransactionInterface transactionInterface)
        {
            _transactionInterface = transactionInterface;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var listofTransactions = await _transactionInterface.GetTransactionsAsync();

            var json = JsonConvert.SerializeObject(listofTransactions, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

            return Ok(json);
        }

        //[HttpPost]
        //[Route("add")]
        //public async Task<IActionResult> AddTransacction(AddTransactionViewModel transaction)
        //{
        //    var res = await _transactionInterface.AddTransactionAsync((Transaction)transaction);
        //    return Ok(res);
        //}

        [HttpPut]


        [Route("update")]
        public async Task<IActionResult> UpdateTrasaction(Transaction transaction)
        {
            transaction = await _transactionInterface.UpdateTransactionAsync(transaction);
            return Ok(transaction);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> Deletetransaction(Guid id)
        {
            await _transactionInterface.DeleteTransactionAsync(id);
            return Ok();
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> GetTransaction(Guid id)
        {
            await _transactionInterface.GetTransactionAsync(id);
            return Ok();
        }

    }
}

