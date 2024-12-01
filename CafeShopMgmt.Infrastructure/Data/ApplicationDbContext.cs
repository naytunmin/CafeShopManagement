using Microsoft.EntityFrameworkCore;
using CafeShopMgmt.Domain.Entities;

namespace CafeShopMgmt.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<CafeShop> CafeShop { get; set; }
        public DbSet<Employee> Employee { get; set; } 
    }
}
