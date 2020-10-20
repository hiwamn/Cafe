using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IDeleteBarginCampaign : IApplicationService
    {
        ApiResult Execute(BaseByIdDto dto);
    }
}
