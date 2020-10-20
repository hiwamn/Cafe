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
    public class GetBarginTypes : IGetBarginTypes
    {
        private readonly IUnitOfWork unit;

        public GetBarginTypes(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public FixedIntResultDto Execute()
        {
            return new FixedIntResultDto
            {
                Object = unit.BarginTypes.GetAll().Select(p=>new FixedIntDto { Id = p.Id, Name = p.Name}).ToList(),
                Status = true
            };
        }
    }

    
}
