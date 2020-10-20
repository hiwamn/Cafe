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
    public class GetUserGamesByPage : IGetUserGamesByPage
    {
        private readonly IUnitOfWork unit;

        public GetUserGamesByPage(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetUserGamesByPageResultDto Execute(GetUserGamesByPageDto dto)
        {
            return unit.Bills.GetUserGamesByPage(dto);            
        }
    }

    
}
