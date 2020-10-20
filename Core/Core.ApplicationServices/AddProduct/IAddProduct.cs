using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IAddProduct : IApplicationService
    {
        ApiResult Execute(AddProductDto dto);
    }
}
