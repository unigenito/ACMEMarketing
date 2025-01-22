using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options) {}

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
                    entry.CurrentValues["CreatedAt"] = DateTime.Now;
                    entry.CurrentValues["UpdatedAt"] = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.CurrentValues["UpdatedAt"] = DateTime.Now;
                    entry.CurrentValues["CreatedAt"] = DateTime.Now;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}