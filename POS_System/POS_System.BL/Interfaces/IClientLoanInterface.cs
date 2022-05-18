using POS_System.ViewModels.Report;

namespace POS_System.BL.Interfaces
{
    public interface IClientLoanInterface
    {
        Task<ClientLoanReportModel> GetClientLoanReportAsync(Guid id);
    }
}
