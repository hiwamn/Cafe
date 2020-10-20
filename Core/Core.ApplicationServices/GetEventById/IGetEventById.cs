using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationServices
{
    public interface IGetEventById : IApplicationService
    {
        GetEventByIdResultDto Execute(BaseByIdDto dto);
    }

    
}
