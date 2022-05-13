using Microsoft.EntityFrameworkCore;
using POS_System.Domains.Inventory;
using POS_System.Domains.Report;
using POS_System.Domains.Selling;
using POS_System.ViewModels.Selling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        //Selling
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<LoanForClient> LoanForClients { get; set; }
        public DbSet<AddOrderViewModel> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SellingProccess> SellingProccesses { get; set; }
        //Inventory
        public DbSet<LoanForInventory> LoanForInventorys { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionProccess> TransactionProccesses { get; set; }
        //Report
        public DbSet<MainReport> MainReports { get; set; }
    }
}
