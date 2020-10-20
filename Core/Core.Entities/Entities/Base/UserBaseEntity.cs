using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public abstract class UserBaseEntity
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public virtual User User { get; set; }
        public long CreatedAt { get; set; }
    }
}
