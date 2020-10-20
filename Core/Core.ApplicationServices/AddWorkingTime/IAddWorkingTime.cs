using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IAddWorkingTime : IApplicationService
    {
        ApiResult Execute(AddWorkingTimeDto dto);
    }
}
