
using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IGetSetting : IApplicationService
    {
        GetSettingResultDto Execute();
    }
}
