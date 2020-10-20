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
    public class GetUsersByPage : IGetUsersByPage
    {
        private readonly IUnitOfWork unit;

        public GetUsersByPage(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetUsersByPageResultDto Execute(GetUsersByPageDto dto)
        {
            return unit.Users.GetUsersByPage(dto);
            
        }
    }

    
}
