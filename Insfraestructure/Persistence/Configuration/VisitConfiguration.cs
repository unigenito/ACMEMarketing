using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class VisitConfiguration: IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.HasKey(v => v.Id);
        builder.Property(v => v.Id).ValueGeneratedOnAdd();
        builder.Property(v => v.VisitDate).IsRequired();
        builder.Property(v => v.VisitedDate);
        builder.Property(v => v.Notes).IsRequired().HasMaxLength(500);
        builder.Property(c => c.IsDeleted).HasDefaultValue(0);
        builder.Property(c => c.CreatedBy).IsRequired();
        builder.Property(c => c.CreatedDate).IsRequired();
         builder.Property(c => c.LastModifiedBy);
        builder.Property(c => c.LastModifiedDate);
        
        builder.HasOne<Customer>(c => c.Customer)
            .WithMany(v => v.Visits)
            .HasForeignKey(c => c.CustomerId);
        
        builder.HasOne<Visitor>(v => v.Visitor)
            .WithMany(v => v.Visits)
            .HasForeignKey(v => v.VisitorId);
        
        builder.ToTable("Visits");
    }
}