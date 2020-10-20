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
    public class GetTeamsByPage : IGetTeamsByPage
    {
        private readonly IUnitOfWork unit;

        public GetTeamsByPage(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetTeamsByPageResultDto Execute(GetTeamsByPageDto dto)
        {
            return unit.Team.GetTeamsByPage(dto);
        }
    }

    
}
