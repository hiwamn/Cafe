using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class ActiveCode : IEntityTypeConfiguration<Core.Entities.ActiveCode>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.ActiveCode> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.Property(p => p.Code).IsRequired().HasMaxLength(10);
            builder.Property(p => p.Mobile).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
 
        }
    }
}