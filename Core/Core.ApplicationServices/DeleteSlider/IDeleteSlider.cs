using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IDeleteSlider : IApplicationService
    {
        ApiResult Execute(BaseByIdDto dto);
    }
}
