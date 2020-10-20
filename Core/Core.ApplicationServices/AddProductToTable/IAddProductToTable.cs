using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IAddProductToTable : IApplicationService
    {
        ApiResult Execute(AddProductToTableDto dto);
    }
}
