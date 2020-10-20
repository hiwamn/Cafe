using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IAddBillItem : IApplicationService
    {
        ApiResult Execute(AddBillItemDto dto);
    }
}
