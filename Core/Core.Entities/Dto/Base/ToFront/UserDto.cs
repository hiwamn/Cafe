
using System;
using System.Collections.Generic;
using Utility.Tools.Auth;

namespace Core.Entities.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; internal set; }
        public long? Birthday { get; internal set; }
        public string Mobile { get; set; }
        public string Bio { get; set; }
        public int Status{ get; set; }
        public string Image { get; internal set; }
        public long CreatedAt { get; internal set; }
        public int? Balance { get; internal set; }
        public int? Gender { get; internal set; }
        public JsonWebToken Token { get; set; }
        public Guid? ProfileImageId { get; internal set; }
        public List<int> Role { get; internal set; }
        public List<BillDto> Bills { get; internal set; }
        public bool CanReserve { get; internal set; }
    }
    public class UserShortDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Mobile { get; internal set; }
    }
    }
