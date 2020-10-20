using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IJoinBarginCampaign : IApplicationService
    {
        ApiResult Execute(JoinBarginCampaignDto dto);
    }
}
