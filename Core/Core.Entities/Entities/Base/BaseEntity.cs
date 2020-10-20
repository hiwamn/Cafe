using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public long CreatedAt { get; set; }
    }
}
