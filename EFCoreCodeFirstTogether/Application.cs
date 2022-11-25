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

                default:
                    break;
            }
        }
    }
}
