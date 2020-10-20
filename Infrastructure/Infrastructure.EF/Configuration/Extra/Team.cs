using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class Team : IEntityTypeConfiguration<Core.Entities.Team>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Team> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.HasOne(p => p.User).WithMany(p => p.MyTeam).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}