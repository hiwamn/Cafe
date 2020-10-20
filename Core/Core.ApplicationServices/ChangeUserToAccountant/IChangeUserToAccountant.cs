using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IChangeUserToAccountant : IApplicationService
    {
        BaseApiResult Execute(ChangeUserToAccountantDto dto);
    }
}
