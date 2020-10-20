using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IAddTeam : IApplicationService
    {
        ApiResult Execute(AddTeamDto dto);
    }
}
