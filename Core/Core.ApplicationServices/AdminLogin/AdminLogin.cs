using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Core.Entities.Functions;
using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility.Tools.Auth;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class AdminLogin : IAdminLogin
    {
        private readonly IUnitOfWork unit;
        private readonly IEncrypter _encrypter;
        private readonly IJwtHandler _jwtHandler;

        public AdminLogin(IUnitOfWork unit,
            IEncrypter encrypter,
            IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this._encrypter = encrypter;
            this._jwtHandler = jwtHandler;
        }
        public LoginResultDto Execute(LoginDto dto)
        {
            User user = unit.Users.GetByMobileIncludingRoles(dto.Mobile);
            LoginResultDto result = new LoginResultDto();
            if (user == null)
                result.Message = Messages.UserNotExist;
            else if (!user.ValidatePassword(dto.Password, _encrypter))
                result.Message = Messages.InvalidPassword;
            else if (user.Status != Enums.EntityStatus.Active.ToInt())
                result.Message = Messages.UserNotActivated;
            else if (user.UserRole == null || !user.UserRole.Any(p => p.RoleId == UserType.Admin.ToInt() || p.RoleId == UserType.Accountant.ToInt()))
                result.Message = Messages.AccessDenied;
            else
            {
                result.Object = DtoBuilder.CreateLoginDto(user);
                result.Object.Token = _jwtHandler.Create(user.Id);
                result.Status = true;
            }
            return result;
        }

    }
}
