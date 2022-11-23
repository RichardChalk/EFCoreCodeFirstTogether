using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.json", true, true);
var config = builder.Build();




