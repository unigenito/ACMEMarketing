using Application.Interfaces;
using Domain.Common;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext: DbContext
{
    private readonly IDateTimeService _dateTimeService;
    
    public AppDbContext(DbContextOptions<AppDbContext> options, IDateTimeService dateTimeService):base(options)
    {
        _dateTimeService = dateTimeService;
    }

    public DbSet<Visit> Visits { get; set; }
    public DbSet<Visitor> Visitors { get; set; }
    public DbSet<Customer> Customers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var entries = ChangeTracker.Entries<BaseAuditEntity>()
            .Where(e => e.State.Equals(EntityState.Modified) && e.Properties.Any(p => p.IsModified) ||
                        e.State.Equals(EntityState.Added));
                        
        foreach (var entry in entries)   
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.CurrentValues["CreatedDate"] = _dateTimeService.NowUtc;
                    entry.CurrentValues["CreatedBy"] = "Uknown";
                    break;
                case EntityState.Modified:
                    entry.CurrentValues["LastModifiedDate"] = _dateTimeService.NowUtc;
                    entry.CurrentValues["LastModifiedBy"] = "Uknown";
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}