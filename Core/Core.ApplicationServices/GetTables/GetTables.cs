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
    public class GetTables : IGetTables
    {
        private readonly IUnitOfWork unit;

        public GetTables(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetTablesResultDto Execute()
        {
            //List<Table> tables = unit.Tables.
            List<Table > tables = unit.Tables.GetAllByDetails();
            return new GetTablesResultDto
            {
                Object = tables.Select(p => DtoBuilder.CreateTableDto(p)).ToList(),
                Status = true
            };
        }
    }

    
}
