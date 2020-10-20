using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class BarginType : IEntityTypeConfiguration<Core.Entities.BarginType>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.BarginType> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.Property(p => p.Id).ValueGeneratedNever();
        }
    }
}