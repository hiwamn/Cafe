using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Document : BaseEntity
    {
        public string Location{ get; set; }        
        public int DocumentType{ get; set; }
        public int Size{ get; set; }
        public int Duration{ get; set; }
        public List<User> UserProfiles { get; set; }
    }
}


