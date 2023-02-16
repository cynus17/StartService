using StartService.Models;

namespace StartService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder service)
        {
            using (var serviceScope = service.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ServiceDbContext>());
            }
        }

        private static void SeedData(ServiceDbContext context)
        {
            if (!context.Accounts.Any())
            {
                Console.WriteLine("Adding data - seeding");

                context.Accounts.AddRange(
                    new Account() 
                );
            }
            else
            {
                Console.WriteLine("Already have data - not seeding");
            }
        }
    }
}