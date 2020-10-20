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
    public class GetEventsByPage : IGetEventsByPage
    {
        private readonly IUnitOfWork unit;

        public GetEventsByPage(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetEventsByPageResultDto Execute(BaseByUserPageDto dto)
        {
            return unit.EventAndLeagues.GetEventsByPage(dto);            
        }
    }

    
}
