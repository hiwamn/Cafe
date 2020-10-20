using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class EditGroupGame : IEditGroupGame
    {

        private readonly IUnitOfWork unit;

        public EditGroupGame(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(EditGroupGameDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.IsUsed };
            GroupGame tbl = unit.GroupGames.Get(dto.Id);            
            tbl.Description = dto.Description;
            tbl.GameTypeId = dto.GameTypeId;
            tbl.Name = dto.Name;
            tbl.StartAt= dto.StartAt;
            tbl.Price = dto.Price;
            return result;
        }
    }
}
