using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IAcceptAllWorkingTime : IApplicationService
    {
        BaseApiResult Execute(AcceptAllWorkingTimeDto dto);
    }
}
