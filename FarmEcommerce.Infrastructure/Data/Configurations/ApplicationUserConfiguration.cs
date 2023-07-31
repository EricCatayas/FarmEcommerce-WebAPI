
using Ecommerce.Domain.Entities;
using FarmEcommerce.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmEcommerce.Infrastructure.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.HasOne(a => a.Images)
                .WithMany()
                .HasForeignKey(a => a.Images_Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Store)
                .WithOne()
                .HasForeignKey<ApplicationUser>(a => a.Store_Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
