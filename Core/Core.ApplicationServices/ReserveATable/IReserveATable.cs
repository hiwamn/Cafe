using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IReserveATable : IApplicationService
    {
        ReserveATableResultDto Execute(ReserveATableDto dto);
    }
}
