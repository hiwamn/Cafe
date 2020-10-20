using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface ISendNotification : IApplicationService
    {
        ApiResult Execute(SendNotificationDto dto);
    }
}
