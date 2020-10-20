using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IAddBarginType : IApplicationService
    {
        ApiResult Execute(AddBarginTypeDto dto);
    }
}
