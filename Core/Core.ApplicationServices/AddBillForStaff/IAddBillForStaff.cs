using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IAddBillForStaff : IApplicationService
    {
        AddBillForStaffResultDto Execute(AddBillForStaffDto dto);
    }
}
