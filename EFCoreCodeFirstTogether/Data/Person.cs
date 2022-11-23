using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstTogether.Data
{
    public class Person
    {
        // 5: Create 'Data' folder.Create classes.
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Range(15,100)]
        public int Age { get; set; }

        public County County { get; set; }
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();

        [Range(1,60)]
        public int ShoeSize { get; set; }
    }
}
