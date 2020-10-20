using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetUsersByPageDto : BaseByPageDto
    {
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Mobile { get; set; }
        public int Status { get; set; }
    }
    public class GetUsersByPageResultDto : BaseApiPageResult
    {
        public List<UserDto> Object { get; set; }
    }
}
