using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IPayBill : IApplicationService
    {
        ApiResult Execute(PayBillDto dto);
    }
}
