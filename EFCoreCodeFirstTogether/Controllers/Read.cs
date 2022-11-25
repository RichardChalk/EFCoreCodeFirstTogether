using EFCoreCodeFirstTogether.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstTogether.Controllers
{
    public class Read : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }
        public Read(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Run()
        {
            // 16: READ READ READ READ READ READ READ READ READ READ READ READ READ READ
            Console.WriteLine("(R)EAD alla personer");
            Console.WriteLine("=====================");

            foreach (var person in dbContext.Person.Include(c => c.County))
            {
                Console.WriteLine($"Namn: {person.Name}");
                Console.WriteLine($"Ålder: {person.Age}");

                if (person.County != null)
                {
                    Console.WriteLine($"County kontakperson: {person.County.ContactPerson}");
                }

                Console.WriteLine("====================");
            }
        }
    }
}
