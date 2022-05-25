using POS_System.BL.Interfaces;
using POS_System.Domains.Report;
using POS_System.BL.Extensions;
using POS_System.Repositories.Interfaces.Selling;

namespace POS_System.BL.Repos
{
    public class SellingReportRepo : ISellingReportInterface
    {
        private readonly IOrderInterface orderInterface;
        private readonly IDepartmentInterface departmentInterface;
        private readonly ILoanForClientInterface loanInterface;

        public SellingReportRepo( IOrderInterface orderInterface,
                                  IDepartmentInterface departmentInterface,
                                  ILoanForClientInterface loanInterface )
        {
            this.orderInterface = orderInterface;
            this.departmentInterface = departmentInterface;
            this.loanInterface = loanInterface;
        }
        public async Task<MainReport> AllSellingReport()
        {
            var ordersList = await orderInterface.GetOrdersAsync();
            double totalIncoming = 0,  totalSelling = 0, netProfit = 0;
            DateTime firstDate = DateTime.Now;
            DateTime lastDate = DateTime.Now;
            
            if (ordersList.Count > 0)
            {
                firstDate = ordersList[0].Date;
                foreach (var order in ordersList)
                {
                    if (order.Date < firstDate)
                    {
                        firstDate = order.Date;
                    }

                    totalIncoming += order.TotalIncomingPrice;

                    if (!order.HasLoan)
                    {
                        totalSelling += order.TotalSellingPrice;
                    }
                    else
                    {
                        var loan = await loanInterface.GetLoanByOrderId(order.Id);
                        totalSelling += loan.PaidPrice;
                    }
                }
                netProfit = totalSelling - totalIncoming;
            }

            MainReport report = new MainReport()
            {
                Id = Guid.NewGuid(),
                StartTime = firstDate,
                EndTime = lastDate,
                TotalIncomingPrice = totalIncoming,
                TotalSellingPrice = totalSelling,
                NetProfit = netProfit
            };

            return report;
        }

        public async Task<MainReport> AllSellingReport(DateTime startDate, DateTime endDate)
        {
            var ordersList = await orderInterface.GetOrdersAsync();
            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            
            foreach (var order in ordersList)
            {
                if (order.Date >= startDate && order.Date <= endDate)
                {
                    if (!order.HasLoan)
                    {
                        totalIncoming += order.TotalIncomingPrice;
                        totalSelling += order.TotalSellingPrice;
                    }
                    else
                    {
                        var loan = await loanInterface.GetLoanByOrderId(order.Id);

                        totalIncoming += order.TotalIncomingPrice;
                        totalSelling += loan.PaidPrice;
                    }
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

            return report;
        }

        public async Task<MainReport> AllSellingReportByDepartmentName(string departmentName)
        {
            var department = (await departmentInterface.GetDepartmentsAsync())
                            .FirstOrDefault(d => d.Name == departmentName);

            var ordersList = (await orderInterface.GetOrdersAsync())
                                .Where(o => o.DepartmentId == department.Id)
                                .ToList();

            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            DateTime firstDate = ordersList[0].Date;
            DateTime lastDate = DateTime.Now;
            foreach (var order in ordersList)
            {
                if (firstDate > order.Date)
                {
                    firstDate = order.Date;
                }
                if (!order.HasLoan)
                {
                    totalIncoming += order.TotalIncomingPrice;
                    totalSelling += order.TotalSellingPrice;
                }
                else
                {
                    var loan = await loanInterface.GetLoanByOrderId(order.Id);

                    totalIncoming += order.TotalIncomingPrice;
                    totalSelling += loan.PaidPrice;
                }
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

            return report;
        }

        public async Task<MainReport> AllSellingReportByDepartmentName(string departmentName, DateTime startDate, DateTime endDate)
        {
            var department = (await departmentInterface.GetDepartmentsAsync())
                            .FirstOrDefault(d => d.Name == departmentName);

            var ordersList = (await orderInterface.GetOrdersAsync())
                                .Where(o => o.DepartmentId == department.Id)
                                .ToList();

            double totalIncoming = 0, totalSelling = 0, netProfit = 0;

            foreach (var order in ordersList)
            {
                if (order.Date >= startDate)
                {
                    string orderDate = order.Date.ToString().Split(" ")[0];
                    if (!order.HasLoan)
                    {
                        totalIncoming += order.TotalIncomingPrice;
                        totalSelling += order.TotalSellingPrice;
                    }
                    else
                    {
                        var loan = await loanInterface.GetLoanByOrderId(order.Id);

                        totalIncoming += order.TotalIncomingPrice;
                        totalSelling += loan.PaidPrice;
                    }
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

            return report;
        }

        public async Task<MainReport> TodaysAllDepartmentSellingReport(string departmentName)
        {
            var department = (await departmentInterface.GetDepartmentsAsync())
                            .FirstOrDefault(d => d.Name == departmentName);

            var ordersList = (await orderInterface.GetOrdersAsync())
                                .Where(o => o.DepartmentId == department.Id)
                                .ToList();

            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            DateTime today = DateTime.Now;
            foreach (var order in ordersList)
            {
                if (today.Equals(order.Date))
                {
                    if (!order.HasLoan)
                    {
                        totalIncoming += order.TotalIncomingPrice;
                        totalSelling += order.TotalSellingPrice;
                    }
                    else
                    {
                        var loan = await loanInterface.GetLoanByOrderId(order.Id);

                        totalIncoming += order.TotalIncomingPrice;
                        totalSelling += loan.PaidPrice;
                    }
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

            return report;
        }

        public async Task<MainReport> TodaysAllSellingReport()
        {
            var ordersList = await orderInterface.GetOrdersAsync();
            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            DateTime today = DateTime.Now;
            foreach (var order in ordersList)
            {
                if (today.Equals(order.Date))
                {
                    if (!order.HasLoan)
                    {
                        totalIncoming += order.TotalIncomingPrice;
                        totalSelling += order.TotalSellingPrice;
                    }
                    else
                    {
                        var loan = await loanInterface.GetLoanByOrderId(order.Id);

                        totalIncoming += order.TotalIncomingPrice;
                        totalSelling += loan.PaidPrice;
                    }
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

            return report;
        }

        public async Task<MainReport> DailyDepartmentSellingReport(string departmentName, DateTime date)
        {
            var department = (await departmentInterface.GetDepartmentsAsync())
                            .FirstOrDefault(d => d.Name == departmentName);

            var ordersList = (await orderInterface.GetOrdersAsync())
                                .Where(o => o.DepartmentId == department.Id)
                                .ToList();

            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            foreach (var order in ordersList)
            {
                if (date.Equals(order.Date))
                {
                    if (!order.HasLoan)
                    {
                        totalIncoming += order.TotalIncomingPrice;
                        totalSelling += order.TotalSellingPrice;
                    }
                    else
                    {
                        var loan = await loanInterface.GetLoanByOrderId(order.Id);

                        totalIncoming += order.TotalIncomingPrice;
                        totalSelling += loan.PaidPrice;
                    }
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

            return report;
        }

        public async Task<MainReport> TodaysSellingReportByDepartmentName(string departmentName)
        {
            var department = (await departmentInterface.GetDepartmentsAsync())
                            .FirstOrDefault(d => d.Name == departmentName);

            var ordersList = (await orderInterface.GetOrdersAsync())
                                .Where(o => o.DepartmentId == department.Id)
                                .ToList();

            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            DateTime today = DateTime.Now;
            foreach (var order in ordersList)
            {
                string orderDate = order.Date.ToString().Split(" ")[0];
                DateOperations dataOperations = new DateOperations();
                if (today.Equals(order.Date))
                {
                    if (!order.HasLoan)
                    {
                        totalIncoming += order.TotalIncomingPrice;
                        totalSelling += order.TotalSellingPrice;
                    }
                    else
                    {
                        var loan = await loanInterface.GetLoanByOrderId(order.Id);

                        totalIncoming += order.TotalIncomingPrice;
                        totalSelling += loan.PaidPrice;
                    }
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

            return report;
        }

        public async Task<MainReport> DailyAllSellingReport(DateTime date)
        {
            var ordersList = await orderInterface.GetOrdersAsync();
            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            foreach (var order in ordersList)
            {
                if (date.Equals(order.Date))
                {
                    if (!order.HasLoan)
                    {
                        totalIncoming += order.TotalIncomingPrice;
                        totalSelling += order.TotalSellingPrice;
                    }
                    else
                    {
                        var loan = await loanInterface.GetLoanByOrderId(order.Id);

                        totalIncoming += order.TotalIncomingPrice;
                        totalSelling += loan.PaidPrice;
                    }
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

            return report;
        }
    }
}
