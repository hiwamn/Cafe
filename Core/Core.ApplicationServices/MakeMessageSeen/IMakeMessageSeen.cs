using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IMakeMessageSeen : IApplicationService
    {
        BaseApiResult Execute(MakeMessageSeenDto dto);
    }
}
