using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IGetAdminDailyWorkingTime : IApplicationService
    {
        GetAdminDailyWorkingTimeResultDto Execute(GetAdminDailyWorkingTimeDto dto);
    }
}
