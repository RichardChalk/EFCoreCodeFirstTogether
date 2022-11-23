using EFCoreCodeFirstTogether.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstTogether
{
    public class Application
    {
        public void Run()
        {
            // 4: Create json builder (boiler plate code)
            // Makes it possible to connect to appsettings.json
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();

            // 6: Create DBContext(boiler plate code).
            // Create options & connectionstring variables(boiler plate code).
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);

            // 7a: Kör i console add-migration "Initial migration"
            // 7b: Migrate DbSets to SQL tabeller
            // Om inte databasen redan finns... så skapas den nu.
            using (var dbContext = new ApplicationDbContext(options.Options))
            {
                var dataInitiaizer = new DatainItializer();
                dataInitiaizer.MigrateAndSeed(dbContext);

                // Migrate har flyttats till dataInitializer class (BEST PRACTISE)
                // dbContext.Database.Migrate();
            }

            // 15: CREATE CREATE CREATE CREATE CREATE CREATE CREATE CREATE CREATE
            using (var dbContext = new ApplicationDbContext(options.Options))
            {
                Console.WriteLine("(C)REATE en ny person");
                Console.WriteLine("=====================");
                
                Console.WriteLine("Ange namn: ");
                var nameInput = Console.ReadLine();

                Console.WriteLine("Ange ålder: ");
                var ageInput = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ange skostorlek: ");
                var shoeSizeInput = Convert.ToInt32(Console.ReadLine());

                foreach (var county in dbContext.County)
                {
                    Console.WriteLine($"{county.Id} - {county.Name}");
                }
                Console.WriteLine("Ange Id på County");
                var countyId = Convert.ToInt32(Console.ReadLine());
                var countyInput = dbContext.County.First(c=>c.Id == countyId);

                dbContext.Person.Add(new Person
                {
                    Age = ageInput,
                    Name = nameInput,
                    ShoeSize = shoeSizeInput,
                    County = countyInput
                });
                dbContext.SaveChanges();
            }
        }
    }
}
