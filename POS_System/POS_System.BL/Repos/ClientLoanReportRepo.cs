using POS_System.BL.Extensions;
using POS_System.BL.Interfaces;
using POS_System.Repositories.Interfaces.Selling;
using POS_System.ViewModels.Report;

namespace POS_System.BL.Repos
{
    public class ClientLoanReportRepo : IClientLoanInterface
    {
        private readonly IClientInterface clientInterface;
        private readonly IOrderInterface orderInterface;
        private readonly ILoanForClientInterface loanForClientInterface;

        public ClientLoanReportRepo(IClientInterface clientInterface,
                                    IOrderInterface orderInterface,
                                    ILoanForClientInterface loanForClientInterface)
        {
            this.clientInterface = clientInterface;
            this.orderInterface = orderInterface;
            this.loanForClientInterface = loanForClientInterface;
        }
        public async Task<ClientLoanReportModel> GetClientLoanReportAsync(Guid id)
        {
            var client = await clientInterface.GetClientAsync(id);
            var clientLoansList = await loanForClientInterface.GetAllClientLoansByClientId(id);
            List<LoanViewModel> loans = new List<LoanViewModel>();

            double totalPrice = 0, leftLoan = 0, paidLoan = 0;
            string startDate = DateTime.Now.ToString().Split(" ")[0];
            DateOperations dateOperations = new DateOperations();
            foreach (var clientLoan in clientLoansList)
            {
                var order = await orderInterface.GetOrderAsync(clientLoan.OrderId);
                if (dateOperations.IsLater(order.Date, startDate))
                {
                    startDate = order.Date;
                }
                totalPrice += order.TotalSellingPrice;
                paidLoan += clientLoan.PaidPrice;
                leftLoan += order.TotalSellingPrice - clientLoan.PaidPrice;
                LoanViewModel loanViewModel = new LoanViewModel()
                {
                    Id = clientLoan.Id,
                    Date = clientLoan.Date,
                    IsPaid = clientLoan.IsPaid,
                    PaidPrice = clientLoan.PaidPrice,
                    LeftPrice = clientLoan.LeftPrice,
                    Order = order
                };
                
                loans.Add(loanViewModel);
            }

            return new ClientLoanReportModel()
            {
                Client = client,
                StartDate = startDate,
                TotalPrice = totalPrice,
                PaidLoan = paidLoan,
                LeftLoan = leftLoan,
                LoansList = loans
            };
        }
    }
}
