using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class City : IEntityTypeConfiguration<Core.Entities.City>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.City> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Property(p => p.Name).IsRequired();
            builder.HasOne(p => p.Province).WithMany(p=>p.City).HasForeignKey(p => p.ProvinceId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}