using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IDeleteGroupGame : IApplicationService
    {
        ApiResult Execute(BaseByIdDto dto);
    }
}
