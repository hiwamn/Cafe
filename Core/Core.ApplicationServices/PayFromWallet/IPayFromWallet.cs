using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IPayFromWallet : IApplicationService
    {
        BaseApiResult Execute(PayFromWalletDto dto);
    }
}
