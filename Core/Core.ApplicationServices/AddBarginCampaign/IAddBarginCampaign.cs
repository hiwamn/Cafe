using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IAddBarginCampaign : IApplicationService
    {
        ApiResult Execute(AddBarginCampaignDto dto);
    }
}
