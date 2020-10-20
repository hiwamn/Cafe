using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IJoinGroupGame : IApplicationService
    {
        ApiResult Execute(JoinGroupGameDto dto);
    }
}
