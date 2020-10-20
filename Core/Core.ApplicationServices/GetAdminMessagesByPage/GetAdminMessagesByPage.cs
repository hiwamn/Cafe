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
    public class GetAdminMessagesByPage : IGetAdminMessagesByPage
    {
        private readonly IUnitOfWork unit;

        public GetAdminMessagesByPage(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetAdminMessagesByPageResultDto Execute(GetAdminMessagesByPageDto dto)
        {
            return unit.Message.GetAdminMessagesByPage(dto);
        }
    }

    
}
