using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class GetGroupGameById : IGetGroupGameById
    {
        private readonly IUnitOfWork unit;

        public GetGroupGameById(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetGroupGameByIdResultDto Execute(BaseByIdDto dto)
        {
            GroupGameDto group = unit.GroupGames.GetById(dto);
            return new GetGroupGameByIdResultDto
            {
                Object = group,
                Status = true
            };
        }
    }

    
}
