using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace Infrastructure.EF.Configuration
{
    public class TableMessage : IEntityTypeConfiguration<Core.Entities.TableMessage>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.TableMessage> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.HasOne(p => p.Table).WithMany(p => p.TableMessage).HasForeignKey(p => p.TableId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}