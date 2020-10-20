using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class EditEvent : IEditEvent
    {

        private readonly IUnitOfWork unit;

        public EditEvent(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(EditEventDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.IsUsed };
            EventAndLeague tbl = unit.EventAndLeagues.Get(dto.Id);            
            tbl.Description = dto.Description;
            tbl.GameTypeId = dto.GameTypeId;
            tbl.Name = dto.Name;
            tbl.StartAt= dto.StartAt;
            tbl.Price = dto.Price;
            tbl.TotalCount = dto.TotalCount;
            unit.Complete();
            return result;
        }
    }
}
