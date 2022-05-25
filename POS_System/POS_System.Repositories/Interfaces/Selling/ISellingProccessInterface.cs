using POS_System.Domains.Pagination;
using POS_System.Domains.Selling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Repositories.Interfaces.Selling
{
    public interface ISellingProccessInterface
    {

        Task<PagedList<SellingProccess>> GetSellingProccesses(QueryStringParameters parameters);
        Task<List<SellingProccess>> GetAllSellingProccessAsync();
        Task<SellingProccess> GetSellingProccessAsync(Guid sellingproccessId);
        Task<SellingProccess> AddSellingProccessAsync(SellingProccess sellingProccess);
        Task<SellingProccess> UpdateSellingProccessAsync(SellingProccess sellingProccess);
        Task DeeleteSellingProccessAsync(Guid sellingproccessId);
        Task<SellingProccess> GetByProductIdSellingProccessAsync(Guid id);
    }
}
