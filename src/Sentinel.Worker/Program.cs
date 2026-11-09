using Sentinel.Worker;
using Microsoft.EntityFrameworkCore;
using Sentinel.Infrastructure;
var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddDbContext<SentinelDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var host = builder.Build();
host.Run();
