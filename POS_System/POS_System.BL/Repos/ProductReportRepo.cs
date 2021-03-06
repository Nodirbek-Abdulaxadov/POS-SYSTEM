using POS_System.BL.Extensions;
using POS_System.BL.Interfaces;
using POS_System.Data;
using POS_System.Domains.Report;
using POS_System.Repositories.Interfaces.Selling;

namespace POS_System.BL.Repos
{
    public class ProductReportRepo : IProductReportInterface
    {
        private readonly IProductInterface productInterface;
        private readonly ISellingProccessInterface sellingProccess;
        private readonly ApplicationDbContext dbContext;

        public ProductReportRepo(ApplicationDbContext dbContext,
                                IProductInterface productInterface,
                                ISellingProccessInterface sellingProccess)
        {
            this.productInterface = productInterface;
            this.sellingProccess = sellingProccess;
            this.dbContext = dbContext;
        }
        public async Task<MainReport> ProductAllReport(string productName)
        {
            var product = await productInterface.GetProductByNameAsync(productName);
            var sellingProccesses = await sellingProccess.GetByProductIdSellingProccessAsync(product.Id);

            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            DateTime firstDate = sellingProccesses[0].Date;
            DateTime lastDate = DateTime.Now;
            foreach (var sellingProccess in sellingProccesses)
            {
                if (firstDate < sellingProccess.Date)
                {
                    firstDate = sellingProccess.Date;
                }
                totalIncoming += sellingProccess.ProccessIncomingPrice;
                totalSelling += sellingProccess.ProccessSellingPrice;
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

        public Task<MainReport> ProductDailyReport(string productName, DateTime date)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Name == productName);
            var sellingProccesses = dbContext.SellingProccesses.Where(sp => sp.ProductId == product.Id).ToList();

            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            foreach (var sellingProccess in sellingProccesses)
            {
                string sellingProccessDate = sellingProccess.Date.ToString().Split(" ")[0];
                DateOperations dataOperations = new DateOperations();
                if (dataOperations.Equals(date.ToString().Split()[0], sellingProccessDate))
                {
                    totalIncoming += sellingProccess.ProccessIncomingPrice;
                    totalSelling += sellingProccess.ProccessSellingPrice;
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

        public Task<MainReport> ProductLastMonthlyReport(string productName)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Name == productName);
            var sellingProccesses = dbContext.SellingProccesses.Where(sp => sp.ProductId == product.Id).ToList();

            DateOperations dataOperations = new DateOperations();
            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            string lastDate = DateTime.Now.ToString().Split(" ")[0];
            string firstDate = dataOperations.NMonthAgo(lastDate, 1);
            foreach (var sellingProccess in sellingProccesses)
            {
                string orderDate = sellingProccess.Date.ToString().Split(" ")[0];
                if (dataOperations.IsLater(firstDate, orderDate))
                {
                    firstDate = orderDate;
                }
                totalIncoming += sellingProccess.ProccessIncomingPrice;
                totalSelling += sellingProccess.ProccessSellingPrice;
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

        public Task<MainReport> ProductLastNDaysReport(string productName, int N)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Name == productName);
            var sellingProccesses = dbContext.SellingProccesses.Where(sp => sp.ProductId == product.Id).ToList();

            DateOperations dataOperations = new DateOperations();
            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            string lastDate = DateTime.Now.ToString().Split(" ")[0];
            string firstDate = dataOperations.NDaysAgo(lastDate, N);
            foreach (var sellingProccess in sellingProccesses)
            {
                string orderDate = sellingProccess.Date.ToString().Split(" ")[0];
                if (dataOperations.IsLater(firstDate, orderDate))
                {
                    firstDate = orderDate;
                }
                totalIncoming += sellingProccess.ProccessIncomingPrice;
                totalSelling += sellingProccess.ProccessSellingPrice;
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

        public Task<MainReport> ProductLastNMonthsReport(string productName, int N)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Name == productName);
            var sellingProccesses = dbContext.SellingProccesses.Where(sp => sp.ProductId == product.Id).ToList();

            DateOperations dataOperations = new DateOperations();
            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            string lastDate = DateTime.Now.ToString().Split(" ")[0];
            string firstDate = dataOperations.NMonthAgo(lastDate, N);
            foreach (var sellingProccess in sellingProccesses)
            {
                string orderDate = sellingProccess.Date.ToString().Split(" ")[0];
                if (dataOperations.IsLater(firstDate, orderDate))
                {
                    firstDate = orderDate;
                }
                totalIncoming += sellingProccess.ProccessIncomingPrice;
                totalSelling += sellingProccess.ProccessSellingPrice;
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

        public Task<MainReport> ProductLastNWeeksReport(string productName, int N)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Name == productName);
            var sellingProccesses = dbContext.SellingProccesses.Where(sp => sp.ProductId == product.Id).ToList();

            DateOperations dataOperations = new DateOperations();
            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            string lastDate = DateTime.Now.ToString().Split(" ")[0];
            string firstDate = dataOperations.NDaysAgo(lastDate, N * 7);
            foreach (var sellingProccess in sellingProccesses)
            {
                string orderDate = sellingProccess.Date.ToString().Split(" ")[0];
                if (dataOperations.IsLater(firstDate, orderDate))
                {
                    firstDate = orderDate;
                }
                totalIncoming += sellingProccess.ProccessIncomingPrice;
                totalSelling += sellingProccess.ProccessSellingPrice;
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

        public Task<MainReport> ProductLastNYearsReport(string productName, int N)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Name == productName);
            var sellingProccesses = dbContext.SellingProccesses.Where(sp => sp.ProductId == product.Id).ToList();

            DateOperations dataOperations = new DateOperations();
            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            string lastDate = DateTime.Now.ToString().Split(" ")[0];
            string firstDate = dataOperations.NYearsAgo(lastDate, N);
            foreach (var sellingProccess in sellingProccesses)
            {
                string orderDate = sellingProccess.Date.ToString().Split(" ")[0];
                if (dataOperations.IsLater(firstDate, orderDate))
                {
                    firstDate = orderDate;
                }
                totalIncoming += sellingProccess.ProccessIncomingPrice;
                totalSelling += sellingProccess.ProccessSellingPrice;
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

        public Task<MainReport> ProductLastWeeklyReport(string productName)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Name == productName);
            var sellingProccesses = dbContext.SellingProccesses.Where(sp => sp.ProductId == product.Id).ToList();

            DateOperations dataOperations = new DateOperations();
            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            string lastDate = DateTime.Now.ToString().Split(" ")[0];
            string firstDate = dataOperations.NDaysAgo(lastDate, 7);
            foreach (var sellingProccess in sellingProccesses)
            {
                string orderDate = sellingProccess.Date.ToString().Split(" ")[0];
                if (dataOperations.IsLater(firstDate, orderDate))
                {
                    firstDate = orderDate;
                }
                totalIncoming += sellingProccess.ProccessIncomingPrice;
                totalSelling += sellingProccess.ProccessSellingPrice;
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

        public Task<MainReport> ProductLastYearlyReport(string productName)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Name == productName);
            var sellingProccesses = dbContext.SellingProccesses.Where(sp => sp.ProductId == product.Id).ToList();

            DateOperations dataOperations = new DateOperations();
            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            string lastDate = DateTime.Now.ToString().Split(" ")[0];
            string firstDate = dataOperations.NYearsAgo(lastDate, 1);
            foreach (var sellingProccess in sellingProccesses)
            {
                string orderDate = sellingProccess.Date.ToString().Split(" ")[0];
                if (dataOperations.IsLater(firstDate, orderDate))
                {
                    firstDate = orderDate;
                }
                totalIncoming += sellingProccess.ProccessIncomingPrice;
                totalSelling += sellingProccess.ProccessSellingPrice;
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

        public Task<MainReport> ProductReport(string productName, DateTime startDate, DateTime endDate)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Name == productName);
            var sellingProccesses = dbContext.SellingProccesses.Where(sp => sp.ProductId == product.Id).ToList();

            DateOperations dataOperations = new DateOperations();
            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            string lastDate = DateTime.Now.ToString().Split(" ")[0];
            string firstDate = startDate.ToString().Split()[0];
            foreach (var sellingProccess in sellingProccesses)
            {
                string orderDate = sellingProccess.Date.ToString().Split(" ")[0];
                if (dataOperations.IsLater(firstDate, orderDate))
                {
                    firstDate = orderDate;
                }
                totalIncoming += sellingProccess.ProccessIncomingPrice;
                totalSelling += sellingProccess.ProccessSellingPrice;
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

        public Task<MainReport> ProductTodaysReport(string productName)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Name == productName);
            var sellingProccesses = dbContext.SellingProccesses.Where(sp => sp.ProductId == product.Id).ToList();

            double totalIncoming = 0, totalSelling = 0, netProfit = 0;
            string today = DateTime.Now.ToString().Split(" ")[0];
            foreach (var sellingProccess in sellingProccesses)
            {
                string sellingProccessDate = sellingProccess.Date.ToString().Split(" ")[0];
                DateOperations dataOperations = new DateOperations();
                if (dataOperations.Equals(today, sellingProccessDate))
                {
                    totalIncoming += sellingProccess.ProccessIncomingPrice;
                    totalSelling += sellingProccess.ProccessSellingPrice;
                }
            }
            netProfit = totalSelling - totalIncoming;

            MainReport report = new MainReport()
            {
                Id = Guid.NewGuid(),
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                TotalIncomingPrice = totalIncoming,
                TotalSellingPrice = totalSelling,
                NetProfit = netProfit
            };

            return Task.FromResult(report);
        }
    }
}
