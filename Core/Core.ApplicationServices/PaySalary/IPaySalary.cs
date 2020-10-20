using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IPaySalary : IApplicationService
    {
        BaseApiResult Execute(PaySalaryDto dto);
    }
}
