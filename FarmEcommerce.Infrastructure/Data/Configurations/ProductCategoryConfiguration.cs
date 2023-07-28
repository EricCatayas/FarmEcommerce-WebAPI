
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmEcommerce.Infrastructure.Data.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<Product_Category>
    {
        public void Configure(EntityTypeBuilder<Product_Category> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Category_Name).IsRequired().HasMaxLength(100);

            builder.HasOne(p => p.Parent_Category)
                .WithMany()
                .HasForeignKey(p => p.Parent_Category_Id)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
