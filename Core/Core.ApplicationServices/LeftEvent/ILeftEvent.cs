using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface ILeftEvent : IApplicationService
    {
        ApiResult Execute(LeftEventDto dto);
    }
}
