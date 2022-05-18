using POS_System.Domains.Selling;

namespace POS_System.ViewModels.Report
{
    public class ClientLoanReportModel
    {
        public Client Client { get; set; }
        public string StartDate { get; set; }
        public double TotalPrice { get; set; }
        public double PaidLoan { get; set; }
        public double LeftLoan { get; set; }
        public List<LoanViewModel>  LoansList { get; set; }
    }
}
