using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IEditGameType : IApplicationService
    {
        ApiResult Execute(EditGameTypeDto dto);
    }
}
