using Microsoft.EntityFrameworkCore;
using POS_System.Domains.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Data
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminRole> Roles { get; set; }
    }
}
