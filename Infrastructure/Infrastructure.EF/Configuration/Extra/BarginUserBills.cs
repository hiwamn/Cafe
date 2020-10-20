using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class BarginUserBills : IEntityTypeConfiguration<Core.Entities.BarginUserBills>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.BarginUserBills> builder)
        {
            builder.HasKey(p => new { p.BarginUsersId , p.BillId});
            builder.HasOne(p => p.BarginUsers).WithMany().HasForeignKey(p => p.BarginUsersId);
            builder.HasOne(p => p.Bill).WithMany().HasForeignKey(p => p.BillId);
        }
    }
}