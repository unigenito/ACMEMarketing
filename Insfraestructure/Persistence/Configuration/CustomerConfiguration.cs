using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class CustomerConfiguration: IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Genere).IsRequired().HasMaxLength(1);
        builder.Property(c => c.Email).IsRequired().HasMaxLength(50);
        builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(15);
        builder.Property(c => c.Street).IsRequired().HasMaxLength(100);
        builder.Property(c => c.City).IsRequired().HasMaxLength(50);
        builder.Property(c => c.ZipCode).IsRequired().HasMaxLength(10);
        builder.Property(c => c.CreatedBy).IsRequired();
        builder.Property(c => c.CreatedDate).IsRequired();
         builder.Property(c => c.LastModifiedBy);
        builder.Property(c => c.LastModifiedDate);
        
        builder.HasMany<Visit>(v => v.Visits)
            .WithOne(v => v.Customer)
            .HasForeignKey(v => v.CustomerId);
    }
}