using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class EventAndLeague : IEntityTypeConfiguration<Core.Entities.EventAndLeague>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.EventAndLeague> builder)
        {
            builder.HasKey(p => new { p.Id });
        }
    }
}