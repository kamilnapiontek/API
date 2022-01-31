using Kolokwium.Api.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Kolokwium.Api.DAL {
    public static class DbExtensions {
        public static void SeedData (this IServiceCollection serviceCollection) {
            var serviceProvider = serviceCollection.BuildServiceProvider ();
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext> ();
            dbContext.AddRange (
                 // example of adding in memory data
                 //new Person()
                 //{
                 //    Id = 1,
                 //    FirstName = "AA",
                 //    LastName = "BB"
                 //},
                 //new Person()
                 //{
                 //    Id = 2,
                 //    FirstName = "CCCAA",
                 //    LastName = "CCCBB"
                 //}
                 new Product
                 {
                     Id = 1,
                     Type = "¯ywnoœæ",
                     Name = "Chleb",
                     Price = 4.00
                 },
                new Product
                {
                    Id = 2,
                    Type = "Elektronika",
                    Name = "Latarka",
                    Price = 40.00
                },
                new Product
                {
                    Id = 3,
                    Type = "¯ywnoœæ",
                    Name = "Chipsy",
                    Price = 6.00
                }
            );
            dbContext.SaveChanges ();
        }
    }
}