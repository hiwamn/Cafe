using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class ProductImage : IEntityTypeConfiguration<Core.Entities.ProductImage>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.ProductImage> builder)
        {
            builder.HasKey(p => new { p.Id });
        }
    }
}