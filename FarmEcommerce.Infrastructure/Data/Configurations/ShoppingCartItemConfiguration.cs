
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmEcommerce.Infrastructure.Data.Configurations
{
    public class ShoppingCartItemConfiguration : IEntityTypeConfiguration<Shopping_Cart_Item>
    {
        public void Configure(EntityTypeBuilder<Shopping_Cart_Item> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Cart_Id).IsRequired();
            builder.Property(a => a.Product_Id).IsRequired();
            builder.Property(a => a.Quantity).IsRequired();
        }
    }
}
