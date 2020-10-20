using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Core.Entities.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class GetGameTypes : IGetGameTypes
    {
        private readonly IUnitOfWork unit;

        public GetGameTypes(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetGameTypesResultDto Execute()
        {
            return new GetGameTypesResultDto
            {
                Object = unit.GameTypes.GetAll().Select(p => DtoBuilder.CreateGameTypeDto(p)).ToList(),
                Status = true
            };
        }
    }

    
}
