using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IDeleteProduct : IApplicationService
    {
        ApiResult Execute(BaseByIdDto dto);
    }
}
