using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IGiveDiscount : IApplicationService
    {
        BaseApiResult Execute(GiveDiscountDto dto);
    }
}
