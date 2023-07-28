
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmEcommerce.Infrastructure.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Order_Total)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder.HasMany(o => o.Lines)
                .WithOne()
                .HasForeignKey(o => o.Order_Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Address)
                .WithMany()
                .HasForeignKey(o => o.Shipping_Address_Id)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasOne(o => o.Shipping_Method)
                .WithMany()
                .HasForeignKey(o => o.Shipping_Method_Id)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasOne(o => o.Status)
                .WithMany()
                .HasForeignKey(o => o.Order_Status_Id)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasOne(o => o.Payment_Method)
                .WithMany()
                .HasForeignKey(o => o.Payment_Method_Id)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
        }
    }
}
