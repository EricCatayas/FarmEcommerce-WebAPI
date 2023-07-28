
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmEcommerce.Infrastructure.Data.Configurations
{
    public class OrderLineConfiguration : IEntityTypeConfiguration<Order_Line>
    {
        public void Configure(EntityTypeBuilder<Order_Line> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Order_Id).IsRequired();
            builder.Property(a => a.Product_Id).IsRequired();
            builder.Property(a => a.Qty).IsRequired();
            builder.Property(a => a.Price).IsRequired().HasColumnType("decimal(18, 2)");
        }
    }
}
