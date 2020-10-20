using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace Infrastructure.EF.Configuration
{
    public class TableReserve : IEntityTypeConfiguration<Core.Entities.TableReserve>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.TableReserve> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.HasOne(p => p.Table).WithMany(p => p.TableReserve).HasForeignKey(p => p.TableId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}