using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IEditBarginCampaign : IApplicationService
    {
        ApiResult Execute(EditBarginCampaignDto dto);
    }
}
