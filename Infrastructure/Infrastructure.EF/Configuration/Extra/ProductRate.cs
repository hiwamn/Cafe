using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class ProductRate : IEntityTypeConfiguration<Core.Entities.ProductRate>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.ProductRate> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.HasOne(p=>p.User).WithMany(p=>p.ProductRate).HasForeignKey(p=>p.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p=>p.Product).WithMany(p=>p.ProductRate).HasForeignKey(p=>p.ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p=>p.Parent).WithMany(p=>p.Children).HasForeignKey(p=>p.ParentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}