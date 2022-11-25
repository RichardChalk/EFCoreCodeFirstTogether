using EFCoreCodeFirstTogether.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstTogether.Controllers
{
    public class Update : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }
        public Update(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Run()
        {
            // 18: UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE
            Console.WriteLine("(U)PDATE en befintlig person");
            Console.WriteLine("=====================");

            // Vilken person ska uppdateras?
            foreach (var person in dbContext.Person)
            {
                Console.WriteLine($"Id: {person.Id}");
                Console.WriteLine($"Namn: {person.Name}");
                Console.WriteLine("====================");
            }

            Console.WriteLine("Välj Id på den Person som du vill uppdatera");
            var personIdToUpdate = Convert.ToInt32(Console.ReadLine());
            var personToUpdate = dbContext.Person.First(p => p.Id == personIdToUpdate);

            // Uppdatera korrekt person
            Console.WriteLine("Ange namn: ");
            var nameUpdate = Console.ReadLine();

            Console.WriteLine("Ange ålder: ");
            var ageUpdate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ange skostorlek: ");
            var shoeSizeUpdate = Convert.ToInt32(Console.ReadLine());

            foreach (var county in dbContext.County)
            {
                Console.WriteLine($"{county.Id} - {county.Name}");
            }
            Console.WriteLine("Ange Id på County");
            var countyIdUpdate = Convert.ToInt32(Console.ReadLine());
            var countyUpdate = dbContext.County.First(c => c.Id == countyIdUpdate);

            // Mappar input info till rätt person
            personToUpdate.Age = ageUpdate;
            personToUpdate.Name = nameUpdate;
            personToUpdate.ShoeSize = shoeSizeUpdate;
            personToUpdate.County = countyUpdate;
            dbContext.SaveChanges();
        }
    }
}
