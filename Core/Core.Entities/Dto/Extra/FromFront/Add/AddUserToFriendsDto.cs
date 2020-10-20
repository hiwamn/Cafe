using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class AddUserToFriendsDto
    {
        public Guid UserId { get; set; }
        public Guid PartnerId { get; set; }
    }
}
