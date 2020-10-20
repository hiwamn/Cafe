using Core.Entities.Dto;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.Auth;

namespace Core.ApplicationServices
{
    public interface IRegisterStaff
    {
        BaseApiResult Execute(RegisterStaffDto dto);
    }
}
