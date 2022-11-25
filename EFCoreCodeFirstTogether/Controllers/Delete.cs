using EFCoreCodeFirstTogether.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstTogether.Controllers
{
    public class Delete : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }
        public Delete(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Run()
        {
            // 19: DELETE DELETE DELETE DELETE DELETE DELETE DELETE DELETE DELETE
            Console.WriteLine("(D)ELETE en befintlig person");
            Console.WriteLine("=====================");

            // Vilken person ska raderas?
            foreach (var person in dbContext.Person)
            {
                Console.WriteLine($"Id: {person.Id}");
                Console.WriteLine($"Namn: {person.Name}");
                Console.WriteLine("====================");
            }

            Console.WriteLine("Välj Id på den Person som du vill radera");
            var personIdToDelete = Convert.ToInt32(Console.ReadLine());
            var personToDelete = dbContext.Person.First(p => p.Id == personIdToDelete);
            dbContext.Person.Remove(personToDelete);

            dbContext.SaveChanges();
        }
    }
}
