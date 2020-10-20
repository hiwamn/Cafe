using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.ApplicationServices
{
    public interface IForgetPassword : IApplicationService
    {
        BaseApiResult Execute(ForgetPasswordDto dto);
    }
}
