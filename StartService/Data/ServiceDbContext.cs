using Microsoft.EntityFrameworkCore;
using StartService.Models;

namespace StartService.Data
{


    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Account> Accounts { get; set; }
    }
}