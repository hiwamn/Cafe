using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface ISendAccountantNotification : IApplicationService
    {
        BaseApiResult Execute(SendAccountantNotificationDto dto);
    }
}
