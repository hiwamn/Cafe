
using System;
using System.Collections.Generic;
using Utility.Tools.Auth;

namespace Core.Entities.Dto
{
    public class UserLoginDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Mobile { get; set; }
        public long CreatedAt { get; set; }
        public JsonWebToken Token { get; set; }
        public long? Birthday { get; internal set; }
        public string Image { get; internal set; }
        public int Role { get; internal set; }
        public bool CanReserve { get; internal set; }
    }
}
