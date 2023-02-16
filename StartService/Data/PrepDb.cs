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
                    new Account() { Id = 1, Code = "A", Password = "123",Name = "Account 1" , Email = "something@gmail.com", Phone = "0373769560" }
                );
                context.SaveChanges();
                Console.WriteLine(context.Accounts.ToList().Count);
            }
            else
            {
                Console.WriteLine("Already have data - not seeding");
            }
        }
    }
}