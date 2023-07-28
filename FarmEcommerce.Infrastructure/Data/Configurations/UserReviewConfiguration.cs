
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmEcommerce.Infrastructure.Data.Configurations
{
    public class UserReviewConfiguration : IEntityTypeConfiguration<User_Review>
    {
        public void Configure(EntityTypeBuilder<User_Review> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.User_Id).IsRequired();
            builder.Property(a => a.Ordered_Product_Id).IsRequired();
            builder.Property(a => a.Rating_Value).IsRequired();
            builder.Property(a => a.Comment).HasMaxLength(1000).IsRequired();
        }
    }
}
