
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmEcommerce.Infrastructure.Data.Configurations
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<User_Payment_Method>
    {
        public void Configure(EntityTypeBuilder<User_Payment_Method> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.UserId).IsRequired();
            builder.Property(a => a.Payment_Type).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Provider).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Account_Number).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Expiry_Date).IsRequired();
            builder.Property(a => a.IsDefault).HasDefaultValue(false);
        }
    }
}
