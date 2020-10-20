using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace Infrastructure.EF.Configuration
{
    public class Bill : IEntityTypeConfiguration<Core.Entities.Bill>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Bill> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.HasOne(p => p.TableReserve).WithMany(p => p.Bill).HasForeignKey(p => p.TableReserveId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.User).WithMany(p => p.Bill).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Promoter).WithMany(p => p.Promoted).HasForeignKey(p => p.PromoterId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}