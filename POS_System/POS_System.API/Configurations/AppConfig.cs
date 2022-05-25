using Microsoft.EntityFrameworkCore;
using POS_System.BL.Interfaces;
using POS_System.BL.Repos;
using POS_System.Data;
using POS_System.Repositories.Interfaces.Identity;
using POS_System.Repositories.Interfaces.Inventory;
using POS_System.Repositories.Interfaces.Selling;
using POS_System.Repositories.Repos.Identity;
using POS_System.Repositories.Repos.Inventory;
using POS_System.Repositories.Repos.Selling;
using Newtonsoft.Json;

namespace POS_System.API.Configurations
{
    public static class AppConfig
    {
        public static void AddDefaultConfigurations(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
        public static void AddDIContainers(this IServiceCollection services)
        {
            services.AddTransient<IAdminInterface, AdminRepo>();
            services.AddTransient<IAdminRoleInterface, AdminRoleRepo>();
            services.AddTransient<ICategoryInterface, CategoryRepo>();
            services.AddTransient<IClientInterface, ClientRepo>();
            services.AddTransient<IDepartmentInterface, DepartmentRepo>();
            services.AddTransient<ILoanForClientInterface, LoanForClientRepo>();
            services.AddTransient<IOrderInterface, OrderRepo>();
            services.AddTransient<IProductInterface, ProductRepo>();
            services.AddTransient<ILoanForInventoryInterface, LoanForInventoryRepo>();
            services.AddTransient<ISupplierInterface, SupplierRepo>();
            services.AddTransient<ITransactionInterface, TransactionRepo>();
            services.AddTransient<ISellingProccessInterface, SellingProccessRepo>();
            services.AddTransient<ITransactionProccessInterface, TransactionProccessRepo>();
            services.AddTransient<ISellingReportInterface, SellingReportRepo>();
            services.AddTransient<IProductReportInterface, ProductReportRepo>();
            services.AddTransient<IClientLoanInterface, ClientLoanReportRepo>();
            
        }

        public static void AddDbContexts(this IServiceCollection services, ConfigurationManager configuration )
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PostgreDB")));
            services.AddDbContext<IdentityDbContext>(options =>
                            options.UseNpgsql(configuration.GetConnectionString("PostgreDB")));
        }

        public static void AddDefaultServiceConfigurations(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
