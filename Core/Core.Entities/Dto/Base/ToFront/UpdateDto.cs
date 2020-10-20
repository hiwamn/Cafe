
using System;
using System.Collections.Generic;
using Utility.Tools.Auth;

namespace Core.Entities.Dto
{
    public class UpdateDto : BaseApiResult
    {
        public Update Object { get; set; }
    }
}
