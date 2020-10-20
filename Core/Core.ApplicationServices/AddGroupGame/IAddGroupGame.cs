using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IAddGroupGame : IApplicationService
    {
        ApiResult Execute(AddGroupGameDto dto);
    }
}
