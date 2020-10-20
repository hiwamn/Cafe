using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IEditTable : IApplicationService
    {
        ApiResult Execute(EditTableDto dto);
    }
}
