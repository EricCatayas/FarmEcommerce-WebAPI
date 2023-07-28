
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmEcommerce.Infrastructure.Data.Configurations
{
    public class ShippingMethodConfiguration : IEntityTypeConfiguration<Shipping_Method>
    {
        public void Configure(EntityTypeBuilder<Shipping_Method> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Price).IsRequired().HasColumnType("decimal(18, 2)");
        }
    }
}
