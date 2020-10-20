using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Utility.Tools.General;
using Utility.Tools.Notification;

namespace Core.ApplicationServices
{
    public class GetReserved : IGetReserved
    {
        private readonly IUnitOfWork unit;


        public GetReserved(IUnitOfWork unit)
        {
            this.unit = unit;

        }

        public GetTablesReserveResultDto Execute()
        {
            return new GetTablesReserveResultDto
            {
                Status = true,
                Object = unit.TableReserve.GetReserved()
            };
        }
    }
}
