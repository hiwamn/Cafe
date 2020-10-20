using Core.Contracts;
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
    public class GetStaffById : IGetStaffById
    {
        private readonly IUnitOfWork unit;

        public GetStaffById(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetUserByIdResultDto Execute(GetUserByIdDto dto)
        {           
            return unit.Users.GetStaffById(dto);            
        }
    }

    
}
