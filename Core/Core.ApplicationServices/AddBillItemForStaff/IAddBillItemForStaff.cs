using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IAddBillItemForStaff : IApplicationService
    {
        AddBillItemForStaffResultDto Execute(AddBillItemDto dto);
    }
}
