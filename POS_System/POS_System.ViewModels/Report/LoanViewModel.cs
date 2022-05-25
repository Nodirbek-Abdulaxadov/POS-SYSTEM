using POS_System.Domains.Selling;

namespace POS_System.ViewModels.Report
{
    public class LoanViewModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public double PaidPrice { get; set; }
        public double LeftPrice { get; set; }
        public bool IsPaid { get; set; }
        public Order Order { get; set; }
    }
}
