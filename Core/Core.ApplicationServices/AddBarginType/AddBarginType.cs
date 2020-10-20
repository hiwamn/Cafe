using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class AddBarginType : IAddBarginType
    {

        private readonly IUnitOfWork unit;

        public AddBarginType(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(AddBarginTypeDto dto)
        {
            ApiResult result = new ApiResult { Status = true,Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();

            
            BarginType bt = new BarginType
            {
                //Id = unit.BarginTypes.GetMeximumId,
                //Name = dto.Name,
                //Description = dto.Description
            };
            unit.BarginTypes.Add(bt);
            unit.Complete();
            result.Object = bt;
            return result;
        }
    }
}
