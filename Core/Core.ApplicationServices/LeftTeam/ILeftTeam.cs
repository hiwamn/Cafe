using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface ILeftTeam : IApplicationService
    {
        ApiResult Execute(LeftTeamDto dto);
    }
}
