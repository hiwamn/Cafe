using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IGetDailyWorkingTime : IApplicationService
    {
        GetDailyWorkingTimeResultDto Execute(GetDailyWorkingTimeDto dto);
    }
}
