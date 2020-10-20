using Core.ApplicationServices;
using Core.Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.EndPoint.Controllers
{
    public class AccountController : SimpleController
    {
        private readonly ILogin login;
        private readonly IRegisterStaff registerUser;
        private readonly IForgetPassword forgetPassword;
        private readonly IAdminLogin adminLogin;

        public AccountController(ILogin login,IRegisterStaff registerUser
            ,IForgetPassword forgetPassword,IAdminLogin adminLogin)
        {
            this.login = login;
            this.registerUser = registerUser;
            this.forgetPassword = forgetPassword;
            this.adminLogin = adminLogin;
        }

        //[HttpPost]
        //public async Task<ActionResult<LoginResultDto>> Login([FromBody]LoginDto dto)
        //{
        //    return login.Execute(dto);
        //}
        

        //[HttpPost]
        //public async Task<ActionResult<LoginResultDto>> Register([FromBody]RegisterUserDto dto)
        //{
        //    return registerUser.Execute(dto);
        //}
        //[HttpPost]
        //public async Task<ActionResult<BaseApiResult>> ForgetPassword([FromBody]ForgetPasswordDto dto)
        //{
        //    return forgetPassword.Execute(dto);
        //}
        
        

    }
}
