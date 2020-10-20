using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IGetLastWeekWorkingTime : IApplicationService
    {
        GetLastWeekWorkingTimeResultDto Execute(GetLastWeekWorkingTimeDto dto);
    }
}
