using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class EventUsers : IEntityTypeConfiguration<Core.Entities.EventUsers>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.EventUsers> builder)
        {
            builder.HasKey(p => new { p.EventAndLeagueId,p.UserId });
        }
    }
}