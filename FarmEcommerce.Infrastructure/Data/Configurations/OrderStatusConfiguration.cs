
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmEcommerce.Infrastructure.Data.Configurations
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<Order_Status>
    {
        public void Configure(EntityTypeBuilder<Order_Status> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Status).IsRequired().HasMaxLength(50);
        }
    }
}
