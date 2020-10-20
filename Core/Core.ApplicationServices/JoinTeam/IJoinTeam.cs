using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IJoinTeam : IApplicationService
    {
        ApiResult Execute(JoinTeamDto dto);
    }
}
