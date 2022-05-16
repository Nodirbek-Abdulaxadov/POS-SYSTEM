using POS_System.Domains.Report;
namespace POS_System.BL.Interfaces
{
    public interface IProductReportInterface
    {
        //barcha hisoboti
        Task<MainReport> ProductAllReport(string productName);
        //bugunlik hisobot
        Task<MainReport> ProductTodaysReport(string productName);
        //kunlik hisobot
        Task<MainReport> ProductDailyReport(string productName, string date);
        //oxirgi haftalik hisobot
        Task<MainReport> ProductLastWeeklyReport(string productName);
        //oxirgi oylik hisobot
        Task<MainReport> ProductLastMonthlyReport(string productName);
        //oxirgi yillik hisobot
        Task<MainReport> ProductLastYearlyReport(string productName);
        //berilgan muddat oralig'idagi hisobot
        Task<MainReport> ProductReport(string productName, string startDate, string endDate);
    }
}
