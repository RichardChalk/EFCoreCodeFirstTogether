using EFCoreCodeFirstTogether.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.Extensions.Configuration;

// 4: Create json builder (boiler plate code)
// Makes it possible to connect to appsettings.json
var builder = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.json", true, true);
var config = builder.Build();

// 6: Create DBContext(boiler plate code).
// Create options & connectionstring variables(boiler plate code).
var options = new DbContextOptionsBuilder<ApplicationDbContext>();
var connectionString = config.GetConnectionString("DefaultConnection");
options.UseSqlServer(connectionString);

// 7: Migrate DbSets to SQL tabeller
// Om inte databasen redan finns... så skapas den nu.
using (var dbContext = new ApplicationDbContext(options.Options))
{
    dbContext.Database.Migrate();
}



