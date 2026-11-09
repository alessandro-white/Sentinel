using Microsoft.EntityFrameworkCore;
using Sentinel.Domain;

namespace Sentinel.Infrastructure;

public class SentinelDbContext : DbContext 
{
    public SentinelDbContext(DbContextOptions<SentinelDbContext> options) : base(options) { }

    public DbSet<Service> Services { get; set; }
}