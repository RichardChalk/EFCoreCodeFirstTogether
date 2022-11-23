using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstTogether.Data
{
    public class Invoice
    {
        // 5: Create 'Data' folder.Create classes.
        [Key]
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDateUtc { get; set; }
    }
}
