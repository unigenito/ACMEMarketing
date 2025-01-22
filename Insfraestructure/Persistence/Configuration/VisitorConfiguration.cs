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
        builder.Property(v => v.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(v => v.LastName).IsRequired().HasMaxLength(50);
        builder.Property(v => v.Email).IsRequired().HasMaxLength(50);
        builder.Property(c => c.CreatedBy).IsRequired();
        builder.Property(c => c.CreatedDate).IsRequired();
         builder.Property(c => c.LastModifiedBy);
        builder.Property(c => c.LastModifiedDate);
    }
}