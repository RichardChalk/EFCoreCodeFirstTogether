using EFCoreCodeFirstTogether.Controllers;
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
            var buildApp = new Build();
            var dbContext = buildApp.BuildApp();

            var sel = MainMenu.ShowMenu();

            switch (sel)
            {
                case 1:
                    {
                        var action = new Create(dbContext);
                        action.Run();
                        break;
                    }
                case 2:
                    {
                        var action = new Read(dbContext);
                        action.Run();
                        break;
                    }
                case 3:
                    {
                        var action = new Update(dbContext);
                        action.Run();
                        break;
                    }

                default:
                    break;
            }

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
