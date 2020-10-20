using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IDeleteGameType : IApplicationService
    {
        ApiResult Execute(BaseByIntIdDto dto);
    }
}
