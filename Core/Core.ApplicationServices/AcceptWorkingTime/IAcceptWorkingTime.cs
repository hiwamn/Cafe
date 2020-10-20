using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IAcceptWorkingTime : IApplicationService
    {
        BaseApiResult Execute(AcceptWorkingTimeDto dto);
    }
}
