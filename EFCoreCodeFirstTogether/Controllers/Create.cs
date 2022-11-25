using EFCoreCodeFirstTogether.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstTogether.Controllers
{
    public class Create : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }
        public Create(ApplicationDbContext context)
        {
            dbContext = context;
        }
        
        public void Run()
        {
            // 15: CREATE CREATE CREATE CREATE CREATE CREATE CREATE CREATE CREATE
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
            var countyInput = dbContext.County.First(c => c.Id == countyId);

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
