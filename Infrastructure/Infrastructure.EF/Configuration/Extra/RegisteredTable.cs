using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class RegisteredTable : IEntityTypeConfiguration<Core.Entities.RegisteredTable>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.RegisteredTable> builder)
        {
            builder.HasKey(p => new { p.Id});
        }
    }
}