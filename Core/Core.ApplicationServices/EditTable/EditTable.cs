using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class EditTable : IEditTable
    {

        private readonly IUnitOfWork unit;

        public EditTable(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(EditTableDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.IsUsed };
            Table tbl = unit.Tables.Get(dto.Id);
            tbl.BarCode = dto.BarCode;
            tbl.Description = dto.Description;
            tbl.MaxCount = dto.MaxCount;
            tbl.Name = dto.Name;
            tbl.StatusId= dto.StatusId;            
            unit.Complete();
            return result;
        }
    }
}
