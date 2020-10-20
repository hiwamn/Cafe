using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IAddMessage : IApplicationService
    {
        ApiResult Execute(AddMessageDto dto);
    }
}
