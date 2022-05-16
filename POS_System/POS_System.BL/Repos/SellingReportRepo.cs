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
            string firstDate = ordersList[0].Date;
            string lastDate = DateTime.Now.ToString().Split(" ")[0];
            foreach (var order in ordersList)
            {
                string orderDate = order.Date.ToString().Split(" ")[0];
                DateOperations dataOperations = new DateOperations();
                if (dataOperations.IsLater(firstDate, orderDate))
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
                StartTime = firstDate,
                EndTime = lastDate,
                TotalIncomingPrice = totalIncoming,
                TotalSellingPrice = totalSelling,
                NetProfit = netProfit
            };

            return Task.FromResult(report);
        }

        public Task<MainReport> AllSellingReport(string startDate, string endDate)
        {
            DateOperations dataOperations = new DateOperations();
            var ordersList = dbContext.Orders.ToList();
            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            
            foreach (var order in ordersList)
            {
                if (dataOperations.IsEarlierOrEqual(startDate, order.Date) && dataOperations.IsLaterOrEqual(endDate, order.Date))
                {
                    string orderDate = order.Date.ToString().Split(" ")[0];
                    totalIncoming += order.TotalIncomingPrice;
                    totalSelling += order.TotalSellingPrice;
                }
            }
            netProfit = totalSelling - totalIncoming;

            MainReport report = new MainReport()
            {
                Id = Guid.NewGuid(),
                StartTime = startDate,
                EndTime = endDate,
                TotalIncomingPrice = totalIncoming,
                TotalSellingPrice = totalSelling,
                NetProfit = netProfit
            };

            return Task.FromResult(report);
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
