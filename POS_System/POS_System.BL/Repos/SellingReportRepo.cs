using POS_System.BL.Interfaces;
using POS_System.Data;
using POS_System.Domains.Report;
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
            var department = dbContext.Departments.FirstOrDefault(d => d.Name == departmentName);
            var ordersList = dbContext.Orders.Where(o => o.DepartmentId == department.Id)
                                                .ToList();
            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
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

        public Task<MainReport> AllSellingReportByDepartmentName(string departmentName, string startDate, string endDate)
        {
            DateOperations dataOperations = new DateOperations();
            var department = dbContext.Departments.FirstOrDefault(d => d.Name == departmentName);
            var ordersList = dbContext.Orders.Where(o => o.DepartmentId == department.Id)
                                                .ToList();
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

        public Task<MainReport> TodaysAllDepartmentSellingReport(string departmentName)
        {
            var department = dbContext.Departments.FirstOrDefault(d => d.Name == departmentName);
            var ordersList = dbContext.Orders.Where(o => o.DepartmentId == department.Id)
                                                .ToList();
            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            string today = DateTime.Now.ToString().Split(" ")[0];
            foreach (var order in ordersList)
            {
                string orderDate = order.Date.ToString().Split(" ")[0];
                DateOperations dataOperations = new DateOperations();
                if (dataOperations.Equals(today, orderDate))
                {
                    totalIncoming += order.TotalIncomingPrice;
                    totalSelling += order.TotalSellingPrice;
                }
            }
            netProfit = totalSelling - totalIncoming;

            MainReport report = new MainReport()
            {
                Id = Guid.NewGuid(),
                StartTime = today,
                EndTime = today,
                TotalIncomingPrice = totalIncoming,
                TotalSellingPrice = totalSelling,
                NetProfit = netProfit
            };

            return Task.FromResult(report);
        }

        public Task<MainReport> TodaysAllSellingReport()
        {
            var ordersList = dbContext.Orders.ToList();
            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            string today = DateTime.Now.ToString().Split(" ")[0];
            foreach (var order in ordersList)
            {
                string orderDate = order.Date.ToString().Split(" ")[0];
                DateOperations dataOperations = new DateOperations();
                if (dataOperations.Equals(today, orderDate))
                {
                    totalIncoming += order.TotalIncomingPrice;
                    totalSelling += order.TotalSellingPrice;
                }
            }
            netProfit = totalSelling - totalIncoming;

            MainReport report = new MainReport()
            {
                Id = Guid.NewGuid(),
                StartTime = today,
                EndTime = today,
                TotalIncomingPrice = totalIncoming,
                TotalSellingPrice = totalSelling,
                NetProfit = netProfit
            };

            return Task.FromResult(report);
        }

        public Task<MainReport> DailyDepartmentSellingReport(string departmentName, string date)
        {
            var department = dbContext.Departments.FirstOrDefault(d => d.Name == departmentName);
            var ordersList = dbContext.Orders.Where(o => o.DepartmentId == department.Id)
                                                .ToList();
            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            foreach (var order in ordersList)
            {
                string orderDate = order.Date.ToString().Split(" ")[0];
                DateOperations dataOperations = new DateOperations();
                if (dataOperations.Equals(date, orderDate))
                {
                    totalIncoming += order.TotalIncomingPrice;
                    totalSelling += order.TotalSellingPrice;
                }
                totalIncoming += order.TotalIncomingPrice;
                totalSelling += order.TotalSellingPrice;
            }
            netProfit = totalSelling - totalIncoming;

            MainReport report = new MainReport()
            {
                Id = Guid.NewGuid(),
                StartTime = date,
                EndTime = date,
                TotalIncomingPrice = totalIncoming,
                TotalSellingPrice = totalSelling,
                NetProfit = netProfit
            };

            return Task.FromResult(report);
        }

        public Task<MainReport> TodaysSellingReportByDepartmentName(string departmentName)
        {
            var department = dbContext.Departments.FirstOrDefault(d => d.Name == departmentName);
            var ordersList = dbContext.Orders.Where(o => o.DepartmentId == department.Id)
                                                .ToList();
            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            string today = DateTime.Now.ToString().Split(" ")[0];
            foreach (var order in ordersList)
            {
                string orderDate = order.Date.ToString().Split(" ")[0];
                DateOperations dataOperations = new DateOperations();
                if (dataOperations.Equals(today, orderDate))
                {
                    totalIncoming += order.TotalIncomingPrice;
                    totalSelling += order.TotalSellingPrice;
                }
                totalIncoming += order.TotalIncomingPrice;
                totalSelling += order.TotalSellingPrice;
            }
            netProfit = totalSelling - totalIncoming;

            MainReport report = new MainReport()
            {
                Id = Guid.NewGuid(),
                StartTime = today,
                EndTime = today,
                TotalIncomingPrice = totalIncoming,
                TotalSellingPrice = totalSelling,
                NetProfit = netProfit
            };

            return Task.FromResult(report);
        }

        public Task<MainReport> DailyAllSellingReport(string date)
        {
            var ordersList = dbContext.Orders.ToList();
            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            foreach (var order in ordersList)
            {
                string orderDate = order.Date.ToString().Split(" ")[0];
                DateOperations dataOperations = new DateOperations();
                if (dataOperations.Equals(date, orderDate))
                {
                    totalIncoming += order.TotalIncomingPrice;
                    totalSelling += order.TotalSellingPrice;
                }
            }
            netProfit = totalSelling - totalIncoming;

            MainReport report = new MainReport()
            {
                Id = Guid.NewGuid(),
                StartTime = date,
                EndTime = date,
                TotalIncomingPrice = totalIncoming,
                TotalSellingPrice = totalSelling,
                NetProfit = netProfit
            };

            return Task.FromResult(report);
        }
    }
}
