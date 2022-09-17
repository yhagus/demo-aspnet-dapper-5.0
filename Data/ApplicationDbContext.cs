using demo_aspnet_dapper_5._0.Models;
using Microsoft.EntityFrameworkCore;

namespace demo_aspnet_dapper_5._0.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
    }
}
