using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IEditProduct : IApplicationService
    {
        ApiResult Execute(EditProductDto dto);
    }
}
