using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IGetDashboard : IApplicationService
    {
        GetDashboardResultDto Execute(GetDashboardDto dto);
    }
}
