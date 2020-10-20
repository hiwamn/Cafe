using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Notification:BaseEntity
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public Guid UserId{ get; set; }
        public User User{ get; set; }
    }
}
