using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IEditWorkingTime : IApplicationService
    {
        BaseApiResult Execute(EditWorkingTimeDto dto);
    }
}
