using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstTogether.Data
{
    public class Person
    {
        // 5: Create 'Data' folder.Create classes.
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
