using EFCoreCodeFirstTogether.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

// Makes it possible to connect to appsettings.json
var builder = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.json", true, true);
var config = builder.Build();

// Define options and connection string
var options = new DbContextOptionsBuilder<ApplicationDbContext>();
var connectionString = config.GetConnectionString("DefaultConnection");
options.UseSqlServer(connectionString);



