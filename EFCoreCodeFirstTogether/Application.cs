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
                case 4:
                    {
                        var action = new Delete(dbContext);
                        action.Run();
                        break;
                    }
                case 0:
                    {
                        break;
                    }

                default:
                    break;
            }

            // TEORI TEORI TEORI TEORI TEORI TEORI TEORI TEORI TEORI TEORI TEORI TEORI
            // TEORI TEORI TEORI TEORI TEORI TEORI TEORI TEORI TEORI TEORI TEORI TEORI
            // TEORI TEORI TEORI TEORI TEORI TEORI TEORI TEORI TEORI TEORI TEORI TEORI
            // TEORI TEORI TEORI TEORI TEORI TEORI TEORI TEORI TEORI TEORI TEORI TEORI

            // POLYMORPHISM POLYMORPHISM POLYMORPHISM POLYMORPHISM POLYMORPHISM
            // POLYMORPHISM POLYMORPHISM POLYMORPHISM POLYMORPHISM POLYMORPHISM
            // POLYMORPHISM POLYMORPHISM POLYMORPHISM POLYMORPHISM POLYMORPHISM
            // POLYMORPHISM POLYMORPHISM POLYMORPHISM POLYMORPHISM POLYMORPHISM

            // Eftersom ALLA mina Actions tillhör Interface 'ICRUD' 
            // ... kan jag skapa en lista som innehåller alla 4 actions
            List<ICrud> actions = new List<ICrud>();

            var c = new Create(dbContext);
            var r = new Read(dbContext);
            var u = new Update(dbContext);
            var d = new Delete(dbContext);

            actions.Add(c);
            actions.Add(r);
            actions.Add(u);
            actions.Add(d);

            foreach (var action in actions)
            {
                // Nu kan jag loopar igenom alla mina actions om jag vill
                // Oavsett om det är en CREATE, READ, UPDATE eller DELTER klass.
                // varje gång jag naropar metoden Run() så väljs den korrekta metoden 
                // beroende på vad det är för klass :)
                
                // tex:
                // action.Run();
            }
        }
    }
}
