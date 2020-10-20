using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IDisableProduct : IApplicationService
    {
        BaseApiResult Execute(DisableProductDto dto);
    }
}
