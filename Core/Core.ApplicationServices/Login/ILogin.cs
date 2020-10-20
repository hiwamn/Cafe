using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationServices
{
    public interface ILogin : IApplicationService
    {
        LoginResultDto Execute(LoginDto dto);
    }
}
