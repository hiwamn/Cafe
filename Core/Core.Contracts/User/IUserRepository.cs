using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        bool IsExistByEmail(string email);
        bool IsExistByMobile(SendActiveCodeDto dto);
        User GetByMobile(string email);
        GetUsersByPageResultDto GetUsersByPage(GetUsersByPageDto dto);
        User GetByEmailIncludingRoles(string email);
        User GetByMobileIncludingRoles(string mobile);
        List<UserShortDto> SearchPeople(SearchPeopleDto dto);
        GetUserByIdResultDto GetUserById(GetUserByIdDto dto);
        GetUserByIdResultDto GetStaffById(GetUserByIdDto dto);
        GetUsersTimeByPageResultDto GetUsersTimeByPage(GetUsersTimeByPageDto dto);
        User GetByDetail(BaseByUserDto dto);
        GetStaffsResultDto GetStaffs(GetStaffsDto dto);
        List<User> GetAllIncludeRoles();
    }
}
