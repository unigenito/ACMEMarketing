using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class VisitorConfiguration: IEntityTypeConfiguration<Visitor>
{
    public void Configure(EntityTypeBuilder<Visitor> builder)
    {
        builder.HasKey(v => v.Id);
        builder.Property(v => v.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.Identification).IsRequired().HasMaxLength(15);
        builder.Property(v => v.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(v => v.LastName).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Genere).IsRequired().HasMaxLength(1);
        builder.Property(v => v.Email).IsRequired().HasMaxLength(50);
        builder.Property(c => c.IsDeleted).HasDefaultValue(0);
        builder.Property(c => c.CreatedBy).IsRequired();
        builder.Property(c => c.CreatedDate).IsRequired();
         builder.Property(c => c.LastModifiedBy);
        builder.Property(c => c.LastModifiedDate);

        builder.HasIndex(c => c.Identification).IsUnique();
        
        builder.HasMany<Visit>(v => v.Visits)
            .WithOne(v => v.Visitor)
            .HasForeignKey(v => v.VisitorId);
        
        builder.ToTable("Visitors");
    }
}