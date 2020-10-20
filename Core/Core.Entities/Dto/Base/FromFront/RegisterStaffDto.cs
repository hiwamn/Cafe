﻿using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Dto
{
    public class RegisterStaffDto
    {        
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public long Birthday { get; set; }
        public string Mobile { get; set; }
    }
}
