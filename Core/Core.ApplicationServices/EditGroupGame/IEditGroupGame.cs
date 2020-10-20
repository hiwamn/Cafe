using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IEditGroupGame : IApplicationService
    {
        ApiResult Execute(EditGroupGameDto dto);
    }
}
