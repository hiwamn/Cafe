using System;
using System.Collections.Generic;
using Utility.Tools.Auth;

namespace Core.Entities.Dto
{
    public class GetUserByIdDto : BaseByUserDto
    {

    }
    public class GetUserByIdResultDto : BaseApiResult
    {
        public GetUserDto Object { get; set; }
    }
   

    public class GetUserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public long? Birthday { get; set; }
        public string Mobile { get; set; }
        public string Bio { get; set; }
        public int Status { get; set; }
        public string Image { get; set; }
        public long CreatedAt { get; set; }
        public int? Balance { get; set; }
        public int? Gender { get; set; }
        public Guid? ProfileImageId { get; set; }
        public List<BillDto> Bills { get; set; }
        public int? Credit { get; internal set; }
        public List<int> Role { get; internal set; }
        public JsonWebToken Token { get; set; }
    }
}
