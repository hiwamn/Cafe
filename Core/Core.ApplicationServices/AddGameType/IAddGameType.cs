using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IAddGameType : IApplicationService
    {
        ApiResult Execute(AddGameTypeDto dto);
    }
}
