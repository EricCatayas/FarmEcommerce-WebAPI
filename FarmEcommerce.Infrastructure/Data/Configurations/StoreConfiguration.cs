
using Ecommerce.Domain.Entities;
using FarmEcommerce.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmEcommerce.Infrastructure.Data.Configurations
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Images_Id).IsRequired();

            builder.HasOne(x => x.Images)
                .WithMany()
                .HasForeignKey(x => x.Images_Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<ApplicationUser>()
                .WithOne(a => a.Store)
                .HasForeignKey<Store>(a => a.Owner_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
