using POS_System.BL.Interfaces;
using POS_System.Data;
using POS_System.Domains.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateTimeHelper;
using POS_System.BL.Extensions;

namespace POS_System.BL.Repos
{
    public class SellingReportRepo : ISellingReportInterface
    {
        private readonly ApplicationDbContext dbContext;

        public SellingReportRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<MainReport> AllSellingReport()
        {
            var ordersList = dbContext.Orders.ToList();
            double totalIncoming = 0,  totalSelling = 0, netProfit = 0;
            string firstDate = DateTime.MaxValue.ToString().Split(" ")[0];
            string lastDate = DateTime.Now.ToString().Split(" ")[0];
            foreach (var order in ordersList)
            {
                string orderDate = order.Date.ToString().Split(" ")[0];
                DateOperations dataOperations = new DateOperations();
                if (dataOperations.IsEarlier(firstDate, orderDate))
                {
                    firstDate = orderDate;
                }
                totalIncoming += order.TotalIncomingPrice;
                totalSelling += order.TotalSellingPrice;
            }
            netProfit = totalSelling - totalIncoming;

            MainReport report = new MainReport()
            {
                Id = Guid.NewGuid(),
                StartTime = DateTime.Parse(firstDate),
                EndTime = DateTime.Parse(lastDate),
                TotalIncomingPrice = totalIncoming,
                TotalSellingPrice = totalSelling,
                NetProfit = netProfit
            };

            return Task.FromResult(report);
        }

        public Task<MainReport> AllSellingReport(DateOnly startDate, DateOnly endDate)
        {
            throw new NotImplementedException();
        }

        public Task<MainReport> AllSellingReportByDepartmentName(string departmentName)
        {
            throw new NotImplementedException();
        }

        public Task<MainReport> AllSellingReportByDepartmentName(string departmentName, DateOnly startDate, DateOnly endDate)
        {
            throw new NotImplementedException();
        }

        public Task<MainReport> DailyAllDepartmentSellingReport()
        {
            throw new NotImplementedException();
        }

        public Task<MainReport> DailyDepartmentSellingReport(string departmentName, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<MainReport> TodaysSellingReportByDepartmentName(string departmentName)
        {
            throw new NotImplementedException();
        }
    }
}
