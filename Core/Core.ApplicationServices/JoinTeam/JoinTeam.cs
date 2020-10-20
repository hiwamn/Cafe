using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class JoinTeam : IJoinTeam
    {

        private readonly IUnitOfWork unit;

        public JoinTeam(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(JoinTeamDto dto)
        {
            ApiResult result = new ApiResult { Status = false, Message = Messages.AlreadyJoined, };
            var now = DateTime.Now.ToUnix();
            if (unit.TeamMember.GetByUserAndTeam(new LeftTeamDto { TeamId = dto.TeamId, UserId = dto.UserId }) == null)
            {
                TeamMember team = new TeamMember
                {
                    CreatedAt = now,
                    UserId = dto.UserId.Value,
                    TeamId = dto.TeamId
                };
                unit.TeamMember.Add(team);
                Team t = unit.Team.Get(dto.TeamId);
                t.Remained--;
                
                unit.Complete();
                result.Status = true;
                result.Message = Messages.Success;
            }
            return result;
        }
    }
}
