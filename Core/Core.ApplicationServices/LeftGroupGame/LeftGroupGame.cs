using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class LeftGroupGame : ILeftGroupGame
    {

        private readonly IUnitOfWork unit;

        public LeftGroupGame(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(LeftGroupGameDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();

            GroupGameUsers gg = unit.GroupGameUsers.GetByUserAndGame(dto);
            unit.GroupGameUsers.Remove(gg);
            GroupGame t = unit.GroupGames.Get(dto.GroupGameId);
            t.RemainedCount--;
            unit.Complete();
            
            return result;
        }
    }
}
