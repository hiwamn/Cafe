using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IAddTable : IApplicationService
    {
        ApiResult Execute(AddTableDto dto);
    }
}
