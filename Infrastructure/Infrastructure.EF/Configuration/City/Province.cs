using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class Province : IEntityTypeConfiguration<Core.Entities.Province>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Province> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Property(p => p.Name).IsRequired();
            builder.HasOne(p => p.Country).WithMany(p => p.Province).HasForeignKey(p => p.CountryId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}