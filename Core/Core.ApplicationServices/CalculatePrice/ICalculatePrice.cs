using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface ICalculatePrice : IApplicationService
    {
        CalculatePriceResultDto Execute(CalculatePriceDto dto);
    }
}
