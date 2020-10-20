using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class BillGames : IEntityTypeConfiguration<Core.Entities.BillGames>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.BillGames> builder)
        {
            builder.HasKey(p => new { p.Id });            
            builder.HasOne(p => p.Bill).WithMany(p => p.BillGames).HasForeignKey(p => p.BillId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}