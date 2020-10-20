using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class LeftTeam : ILeftTeam
    {

        private readonly IUnitOfWork unit;

        public LeftTeam(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(LeftTeamDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();

            TeamMember team = unit.TeamMember.GetByUserAndTeam(dto);
            unit.TeamMember.Remove(team);
            Team t = unit.Team.Get(dto.TeamId);
            t.Remained--;
            unit.Complete();
            
            return result;
        }
    }
}
