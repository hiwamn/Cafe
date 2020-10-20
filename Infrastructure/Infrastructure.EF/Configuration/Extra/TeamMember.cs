using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class TeamMember : IEntityTypeConfiguration<Core.Entities.TeamMember>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.TeamMember> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.HasOne(p => p.User).WithMany(p => p.JoindTeam).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}