using Core.ApplicationServices;
using Core.Entities.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.EndPoint.Controllers
{
    public class UserController : SimpleController
    {
        private readonly IChangeUserStatus changeUserStatus;
        private readonly IEditProfile editProfile;
        private readonly IGetWallet getWallet;
        private readonly IGetTransactionsByPage getTransactionsByPage;
        private readonly IGetUserTransactionPartners getUserTransactionPartners;
        private readonly ISearchPeople searchPeople;
        private readonly IAddUserToFriends addUserToFriends;
        private readonly ISendMoney sendMoney;
        private readonly IReserveATable reserveATable;
        private readonly IGetUserById getUserById;
        private readonly IAddWorkingTime addWorkingTime;
        private readonly IGetLastWeekWorkingTime getLastWeekWorkingTime;
        private readonly IGetDailyWorkingTime getDailyWorkingTime;
        private readonly IGetHybridTransactions getHybridTransactions;
        private readonly IChangeUserReserveAccess changeUserReserveAccess;

        public UserController(
            IChangeUserStatus changeUserStatus,
            IEditProfile setProfileImage,
            IGetWallet getWallet,
            IGetTransactionsByPage getTransactionsByPage,
            IGetUserTransactionPartners getUserTransactionPartners,
            ISearchPeople searchPeople,
            IAddUserToFriends addUserToFriends,
            ISendMoney sendMoney,
            IReserveATable reserveATable,
            IGetUserById getUserById,
            IAddWorkingTime addWorkingTime,
            IGetLastWeekWorkingTime getLastWeekWorkingTime,
            IGetDailyWorkingTime getDailyWorkingTime,
            IGetHybridTransactions getHybridTransactions,
            IChangeUserReserveAccess changeUserReserveAccess
            )
        {
            this.changeUserStatus = changeUserStatus;
            this.editProfile = setProfileImage;
            this.getWallet = getWallet;
            this.getTransactionsByPage = getTransactionsByPage;
            this.getUserTransactionPartners = getUserTransactionPartners;
            this.searchPeople = searchPeople;
            this.addUserToFriends = addUserToFriends;
            this.sendMoney = sendMoney;
            this.reserveATable = reserveATable;
            this.getUserById = getUserById;
            this.addWorkingTime = addWorkingTime;
            this.getLastWeekWorkingTime = getLastWeekWorkingTime;
            this.getDailyWorkingTime = getDailyWorkingTime;
            this.getHybridTransactions = getHybridTransactions;
            this.changeUserReserveAccess = changeUserReserveAccess;
        }

        [HttpPost]
        public ActionResult<BaseApiResult> EditProfile([FromBody] EditProfileDto dto)
        {
            return editProfile.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetWalletResultDto> GetWallet([FromQuery] BaseByUserDto dto)
        {
            return getWallet.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetTransactionsByPageResultDto> GetTransactionsByPage([FromQuery] BaseByUserPageDto dto)
        {
            return getTransactionsByPage.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetUserTransactionPartnersResultDto> GetUserTransactionPartners([FromQuery] BaseByUserDto dto)
        {
            return getUserTransactionPartners.Execute(dto);
        }
        [HttpGet]
        public ActionResult<SearchPeopleResultDto> SearchPeople([FromQuery] SearchPeopleDto dto)
        {
            return searchPeople.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> AddUserToFriends([FromBody] AddUserToFriendsDto dto)
        {
            return addUserToFriends.Execute(dto);
        }
        [HttpPost]
        public ActionResult<BaseApiResult> SendMoney([FromBody] SendMoneyDto dto)
        {
            return sendMoney.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ReserveATableResultDto> ReserveATable([FromBody] ReserveATableDto dto)
        {
            return reserveATable.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetUserByIdResultDto> GetUserById([FromQuery] GetUserByIdDto dto)
        {
            return getUserById.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> AddWorkingTime([FromBody] AddWorkingTimeDto dto)
        {
            return addWorkingTime.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetLastWeekWorkingTimeResultDto> GetLastWeekWorkingTime([FromQuery] GetLastWeekWorkingTimeDto dto)
        {
            return getLastWeekWorkingTime.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetDailyWorkingTimeResultDto> GetDailyWorkingTime([FromQuery] GetDailyWorkingTimeDto dto)
        {
            return getDailyWorkingTime.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetHybridTransactionsResultDto> GetHybridTransactions([FromQuery] GetHybridTransactionsDto dto)
        {
            return getHybridTransactions.Execute(dto);
        }
        [HttpPost]
        public ActionResult<BaseApiResult> ChangeUserReserveAccess([FromBody] ChangeUserReserveAccessDto dto)
        {
            return changeUserReserveAccess.Execute(dto);
        }
    }
}
