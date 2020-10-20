using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IEditEvent : IApplicationService
    {
        ApiResult Execute(EditEventDto dto);
    }
}
