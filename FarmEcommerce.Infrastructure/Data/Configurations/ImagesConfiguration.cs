
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmEcommerce.Infrastructure.Data.Configurations
{
    public class ImagesConfiguration : IEntityTypeConfiguration<Images>
    {
        public void Configure(EntityTypeBuilder<Images> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasMany(i => i.Uploads)
              .WithOne(u => u.Images)
              .HasForeignKey(u => u.Images_Id)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }    
}
