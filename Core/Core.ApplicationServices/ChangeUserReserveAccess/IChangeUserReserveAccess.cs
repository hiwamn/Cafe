using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IChangeUserReserveAccess : IApplicationService
    {
        BaseApiResult Execute(ChangeUserReserveAccessDto dto);
    }
}
