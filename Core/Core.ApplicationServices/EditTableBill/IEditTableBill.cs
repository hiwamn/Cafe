using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IEditTableBill : IApplicationService
    {
        EditTableBillResultDto Execute(EditTableBillDto dto);
    }
}
