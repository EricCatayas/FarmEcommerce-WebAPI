
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmEcommerce.Infrastructure.Data.Configurations
{
    public class UserAddressConfiguration : IEntityTypeConfiguration<User_Address>
    {
        public void Configure(EntityTypeBuilder<User_Address> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Address_Id).IsRequired();
            builder.Property(a => a.Is_Default).HasDefaultValue(false).IsRequired();
        }
    }
}
