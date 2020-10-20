
using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IUpdateSetting : IApplicationService
    {
        BaseApiResult Execute(SettingDto dto);
    }
}
