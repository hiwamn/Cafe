using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface ILeftGroupGame : IApplicationService
    {
        ApiResult Execute(LeftGroupGameDto dto);
    }
}
