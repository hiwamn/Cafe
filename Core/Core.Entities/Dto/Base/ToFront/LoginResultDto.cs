using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities.Dto
{
    public class LoginResultDto : BaseApiResult
    {
        public UserLoginDto Object { get; set; }
    }
    
}
