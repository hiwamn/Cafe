using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class BillItem : IEntityTypeConfiguration<Core.Entities.BillItem>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.BillItem> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.HasOne(p => p.Product).WithMany(p => p.BillItem).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Bill).WithMany(p => p.BillItem).HasForeignKey(p => p.BillId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}