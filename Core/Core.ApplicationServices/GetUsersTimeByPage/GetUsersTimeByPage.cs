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
    public class GetUsersTimeByPage : IGetUsersTimeByPage
    {
        private readonly IUnitOfWork unit;

        public GetUsersTimeByPage(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetUsersTimeByPageResultDto Execute(GetUsersTimeByPageDto dto)
        {
            return unit.Users.GetUsersTimeByPage(dto);
            
        }
    }

    
}
