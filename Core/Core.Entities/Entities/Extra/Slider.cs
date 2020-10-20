using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class Slider : BaseEntity
    {
        public Document Document { get; set; }
        public Guid DocumentId { get; set; }
        
    }
}
