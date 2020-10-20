using System.Collections;
using System.Threading.Tasks;

namespace Utility.Tools.Notification
{
    public interface INotification
    {
        Task<string> SendAsync(string Text,string Destination);
        Task<int> CheckDeliveryAsync(string FollowingCode);
        Task<long> GetBalance();
    }
}
