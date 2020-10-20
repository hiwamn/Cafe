using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IEditSlider : IApplicationService
    {
        ApiResult Execute(EditSliderDto dto);
    }
}
