using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstTogether.Data
{
    public class ApplicationDbContext : DbContext
    {
        // 6: Create DBContext(boiler plate code). Create options & connectionstring variables(boiler plate code).

        public DbSet<Person> Person { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<County> County { get; set; }

        public ApplicationDbContext()
        {
            // en tom konstruktor behövs för att skapa migrations
        }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=Invoice12345;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }

    }
}
