using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IAddUserToFriends : IApplicationService
    {
        ApiResult Execute(AddUserToFriendsDto dto);
    }
}
