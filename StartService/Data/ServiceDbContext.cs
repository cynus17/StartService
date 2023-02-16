using Microsoft.EntityFrameworkCore;
using StartService.Models;

namespace StartService.Data
{


    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> opt) : base(opt)
        {

        }

        public DbSet<Account> Accounts { get; set; }
    }
}