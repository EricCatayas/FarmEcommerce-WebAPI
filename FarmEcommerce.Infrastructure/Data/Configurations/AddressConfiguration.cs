
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmEcommerce.Infrastructure.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Street).IsRequired().HasMaxLength(500);
            builder.Property(a => a.Barangay).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Postal_Code).HasMaxLength(10);

            builder.HasOne(a => a.Municipality)
                  .WithMany() // No navigation property on City for this relationship
                  .HasForeignKey(a => a.Municipality_Id)
                  .OnDelete(DeleteBehavior.Restrict);            
        }
    }
}
