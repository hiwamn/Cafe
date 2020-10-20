using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class GameType : IEntityTypeConfiguration<Core.Entities.GameType>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.GameType> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.Property(p => p.Id).ValueGeneratedNever();
        }
    }
}