using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class DeleteGameType : IDeleteGameType
    {

        private readonly IUnitOfWork unit;

        public DeleteGameType(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(BaseByIntIdDto dto)
        {
            ApiResult result = new ApiResult { Status = false, Message = Messages.IsUsed };

            var gt = unit.GameTypes.Get(dto.Id);
            try
            {
                unit.GameTypes.Remove(gt);
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
