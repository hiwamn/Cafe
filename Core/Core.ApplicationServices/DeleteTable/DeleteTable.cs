using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class DeleteTable : IDeleteTable
    {

        private readonly IUnitOfWork unit;

        public DeleteTable(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(BaseByIdDto dto)
        {
            ApiResult result = new ApiResult { Status = false, Message = Messages.IsUsed };

            var tbl = unit.Tables.Get(dto.Id);
            try
            {
                unit.Tables.Remove(tbl);
                unit.Complete();
                result.Status = true;
                result.Message = Messages.Success;
            }
            catch 
            {
            }
            return result;
        }
    }
}
