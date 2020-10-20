using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IDeleteTable : IApplicationService
    {
        ApiResult Execute(BaseByIdDto dto);
    }
}
