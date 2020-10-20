﻿using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class GetStaffs : IGetStaffs
    {
        private readonly IUnitOfWork unit;

        public GetStaffs(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetStaffsResultDto Execute(GetStaffsDto dto)
        {
            return unit.Users.GetStaffs(dto);
            
        }
    }

    
}
