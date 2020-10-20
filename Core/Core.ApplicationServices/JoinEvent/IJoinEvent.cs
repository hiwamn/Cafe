using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IJoinEvent : IApplicationService
    {
        ApiResult Execute(JoinEventDto dto);
    }
}
