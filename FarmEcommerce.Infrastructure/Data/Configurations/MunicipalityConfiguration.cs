
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmEcommerce.Infrastructure.Data.Configurations
{
    public class MunicipalityConfiguration : IEntityTypeConfiguration<Municipality>
    {
        public void Configure(EntityTypeBuilder<Municipality> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(a => a.Id).IsRequired();
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(a => a.Province)
                .WithMany()
                .HasForeignKey(a => a.Province_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
