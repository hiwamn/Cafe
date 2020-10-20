using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IAddGameToTable : IApplicationService
    {
        AddGameToTableResultDto Execute(AddGameToTableDto dto);
    }
}
