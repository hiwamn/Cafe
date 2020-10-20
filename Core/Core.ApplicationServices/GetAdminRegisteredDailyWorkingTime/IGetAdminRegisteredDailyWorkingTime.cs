using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IGetAdminRegisteredDailyWorkingTime : IApplicationService
    {
        GetAdminRegisteredDailyWorkingTimeResultDto Execute(GetAdminRegisteredDailyWorkingTimeDto dto);
    }
}
