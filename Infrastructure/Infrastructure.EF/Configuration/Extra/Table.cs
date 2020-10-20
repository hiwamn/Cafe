using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class Table : IEntityTypeConfiguration<Core.Entities.Table>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Table> builder)
        {
            builder.HasKey(p => new { p.Id });
        }
    }
}