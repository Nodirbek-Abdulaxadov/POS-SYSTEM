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

        public async Task<MainReport> AllSellingReport(string startDate, string endDate)
        {
            DateOperations dataOperations = new DateOperations();
            var ordersList = await orderInterface.GetOrdersAsync();
            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            
            foreach (var order in ordersList)
            {
                if (dataOperations.IsEarlierOrEqual(startDate, order.Date) && dataOperations.IsLaterOrEqual(endDate, order.Date))
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

        public async Task<MainReport> AllSellingReportByDepartmentName(string departmentName)
        {
            var department = (await departmentInterface.GetDepartmentsAsync())
                            .FirstOrDefault(d => d.Name == departmentName);

            var ordersList = (await orderInterface.GetOrdersAsync())
                                .Where(o => o.DepartmentId == department.Id)
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

        public async Task<MainReport> AllSellingReportByDepartmentName(string departmentName, string startDate, string endDate)
        {
            DateOperations dataOperations = new DateOperations();
            var department = (await departmentInterface.GetDepartmentsAsync())
                            .FirstOrDefault(d => d.Name == departmentName);

            var ordersList = (await orderInterface.GetOrdersAsync())
                                .Where(o => o.DepartmentId == department.Id)
                                .ToList();

            double totalIncoming = 0, totalSelling = 0, netProfit = 0;

            foreach (var order in ordersList)
            {
                if (dataOperations.IsEarlierOrEqual(startDate, order.Date) && dataOperations.IsLaterOrEqual(endDate, order.Date))
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
            string today = DateTime.Now.ToString().Split(" ")[0];
            foreach (var order in ordersList)
            {
                string orderDate = order.Date.ToString().Split(" ")[0];
                DateOperations dataOperations = new DateOperations();
                if (dataOperations.Equals(today, orderDate))
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
            string today = DateTime.Now.ToString().Split(" ")[0];
            foreach (var order in ordersList)
            {
                string orderDate = order.Date.ToString().Split(" ")[0];
                DateOperations dataOperations = new DateOperations();
                if (dataOperations.Equals(today, orderDate))
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

        public async Task<MainReport> DailyDepartmentSellingReport(string departmentName, string date)
        {
            var department = (await departmentInterface.GetDepartmentsAsync())
                            .FirstOrDefault(d => d.Name == departmentName);

            var ordersList = (await orderInterface.GetOrdersAsync())
                                .Where(o => o.DepartmentId == department.Id)
                                .ToList();

            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            foreach (var order in ordersList)
            {
                string orderDate = order.Date.ToString().Split(" ")[0];
                DateOperations dataOperations = new DateOperations();
                if (dataOperations.Equals(date, orderDate))
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
            string today = DateTime.Now.ToString().Split(" ")[0];
            foreach (var order in ordersList)
            {
                string orderDate = order.Date.ToString().Split(" ")[0];
                DateOperations dataOperations = new DateOperations();
                if (dataOperations.Equals(today, orderDate))
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

        public async Task<MainReport> DailyAllSellingReport(string date)
        {
            var ordersList = await orderInterface.GetOrdersAsync();
            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            foreach (var order in ordersList)
            {
                string orderDate = order.Date.ToString().Split(" ")[0];
                DateOperations dataOperations = new DateOperations();
                if (dataOperations.Equals(date, orderDate))
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
