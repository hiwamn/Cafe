using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IAddEventAndLeague : IApplicationService
    {
        ApiResult Execute(AddEventAndLeagueDto dto);
    }
}
