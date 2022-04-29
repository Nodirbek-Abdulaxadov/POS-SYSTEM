using Microsoft.EntityFrameworkCore;
using POS_System.Data;
using POS_System.Repositories.Interfaces.Identity;
using POS_System.Repositories.Repos.Identity;

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
