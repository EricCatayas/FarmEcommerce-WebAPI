
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmEcommerce.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18, 2)");
            builder.Property(p => p.Description).HasMaxLength(1000);
            builder.Property(p => p.Images_Id).IsRequired();
            builder.Property(p => p.Store_Id).IsRequired();

            builder.HasOne(p => p.Store)
                .WithMany()
                .HasForeignKey(p => p.Store_Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Images)
               .WithOne()
               .HasForeignKey<Product>(p => p.Images_Id)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Discount)
                .WithMany()
                .HasForeignKey(p => p.Discount_Id)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.Category_Id)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
