using Microsoft.EntityFrameworkCore;

namespace SnapshotFinancial.Data;

public class NetworthDbContext : DbContext
{
    public DbSet<NetworthRecord> NetworthRecords { get; set; }

    public NetworthDbContext(DbContextOptions<NetworthDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NetworthRecord>().HasKey(r => r.Id);
    }
}
