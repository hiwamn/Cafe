using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class GroupGame : IEntityTypeConfiguration<Core.Entities.GroupGame>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.GroupGame> builder)
        {
            builder.HasKey(p => new { p.Id });
        }
    }
}