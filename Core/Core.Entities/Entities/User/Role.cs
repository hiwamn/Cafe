using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserRole> UserRole { get; set; }

    }
}
