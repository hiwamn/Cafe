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
    public class GetEventById : IGetEventById
    {
        private readonly IUnitOfWork unit;

        public GetEventById(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetEventByIdResultDto Execute(BaseByIdDto dto)
        {
            EventAndLeagueDto @event = unit.EventAndLeagues.GetById(dto);
            return new GetEventByIdResultDto
            {
                Object = @event,
                Status = true
            };
        }
    }

    
}
