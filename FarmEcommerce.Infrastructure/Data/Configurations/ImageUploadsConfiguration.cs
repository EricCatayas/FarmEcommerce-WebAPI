
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmEcommerce.Infrastructure.Data.Configurations
{
    public class ImageUploadsConfiguration : IEntityTypeConfiguration<Image_Upload>
    {
        public void Configure(EntityTypeBuilder<Image_Upload> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Image_Url).IsRequired().HasMaxLength(1028);

            builder.HasOne(x => x.Images)
                .WithMany(x => x.Uploads)
                .HasForeignKey(x => x.Images_Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
