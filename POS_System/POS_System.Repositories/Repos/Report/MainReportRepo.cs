using Microsoft.EntityFrameworkCore;
using POS_System.Data;
using POS_System.Domains.Report;
using POS_System.Repositories.Interfaces.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Repositories.Repos.Report
{
    public class MainReportRepo : IMainReportInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public MainReportRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<MainReport> AddMainReportAsync(MainReport mainReport)
        {
            _dbContext.MainReports.Add(mainReport);
            _dbContext.SaveChanges();
            return Task.FromResult(mainReport);
        }

        public Task DeleteMainReportAsync(Guid mainreportId)
        {
            _dbContext.MainReports.Remove(_dbContext.MainReports.FirstOrDefault(p => p.Id == mainreportId));
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<MainReport> GetMainReportAsync(Guid mainreportId) =>
            _dbContext.MainReports.FirstOrDefaultAsync(p => p.Id == mainreportId);

        public Task<List<MainReport>> GetMainReportsAsync() =>
            _dbContext.MainReports.ToListAsync();

        public Task<MainReport> UpdateMainReportAsync(MainReport mainReport)
        {
            _dbContext.MainReports.Update(mainReport);
            _dbContext.SaveChanges();
            return Task.FromResult(mainReport);
        }
    }
}
