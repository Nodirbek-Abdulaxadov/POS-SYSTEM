using POS_System.Domains.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.BL.Interfaces
{
    public interface ISellingReportInterface
    {
        //boshidan oxirigacha
        Task<MainReport> AllSellingReport();
        //bugunlik barcha hisobot
        Task<MainReport> TodaysAllSellingReport();
        //kunlik barcha hisobot
        Task<MainReport> DailyAllSellingReport(string date);
        //sanadan sanagacha hisobot
        Task<MainReport> AllSellingReport(string startDate, string endDate);
        //nomi bo'yicha departmentning umumiy hisoboti
        Task<MainReport> AllSellingReportByDepartmentName(string departmentName);
        //barcha departmentlarning kunlik hisoboti
        Task<MainReport> TodaysAllDepartmentSellingReport(string departmentName);
        //nomi bo'yicha departmentning istalgan kunlik hisoboti
        Task<MainReport> DailyDepartmentSellingReport(string departmentName, string date);
        //nomi bo'yicha departmentning bugungi hisoboti
        Task<MainReport> TodaysSellingReportByDepartmentName(string departmentName);        
        Task<MainReport> AllSellingReportByDepartmentName(string departmentName, string startDate, string endDate);

    }
}
