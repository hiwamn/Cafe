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
    public class GetGroupGamesByPage : IGetGroupGamesByPage
    {
        private readonly IUnitOfWork unit;

        public GetGroupGamesByPage(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetGroupGamesByPageResultDto Execute(BaseByUserPageDto dto)
        {
            return unit.GroupGames.GetGroupGamesByPage(dto);            
        }
    }

    
}
