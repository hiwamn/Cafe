using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IAddSlider : IApplicationService
    {
        ApiResult Execute(AddSliderDto dto);
    }
}
