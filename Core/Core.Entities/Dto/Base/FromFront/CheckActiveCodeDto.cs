using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class CheckActiveCodeDto
    {
        public string ActiveCode { get; set; }
        public string Mobile { get; set; }
        public string PushId { get; set; }
        public int? RoleId { get; set; }
    }
    public class CheckActiveCodeResultDto : BaseApiResult
    {
        public UserDto Object { get; set; }
    }
}
