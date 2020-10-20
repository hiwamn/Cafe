using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class Slider : IEntityTypeConfiguration<Core.Entities.Slider>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Slider> builder)
        {
            builder.HasKey(p => new { p.Id });
        }
    }
}