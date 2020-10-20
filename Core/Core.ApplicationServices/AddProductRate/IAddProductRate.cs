using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IAddProductRate : IApplicationService
    {
        ApiResult Execute(AddProductRateDto dto);
    }
}
