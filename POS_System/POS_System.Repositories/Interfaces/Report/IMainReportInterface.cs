using POS_System.Domains.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Repositories.Interfaces.Report
{
    public interface IMainReportInterface
    {
        Task<List<MainReport>> GetMainReportsAsync();
        Task<MainReport> GetMainReportAsync(Guid mainreportId);
        Task<MainReport> AddMainReportAsync(MainReport mainReport);
        Task<MainReport> UpdateMainReportAsync(MainReport mainReport);
        Task DeleteMainReportAsync(Guid mainreportId);
    }
}
