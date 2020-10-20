using System.Threading.Tasks;
using Utility.Tools.Auth;

namespace Infrastructure.Identity.Services
{
    public interface IUserService
    {
         Task RegisterAsync(string email, string password, string name);
         Task<JsonWebToken> LoginAsync(string email, string password);
    }
}