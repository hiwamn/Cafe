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
    public class AddTable : IAddTable
    {

        private readonly IUnitOfWork unit;

        public AddTable(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(AddTableDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();

            Table table = new Table
            {
                CreatedAt = now,
                BarCode = dto.BarCode,
                Description = dto.Description,
                MaxCount = dto.MaxCount,
                Name = dto.Name,
                No = dto.No,
                StatusId = TableStatus.Free.ToInt()
            };
            unit.Tables.Add(table);
            unit.Complete();
            
            return result;
        }
    }
}
