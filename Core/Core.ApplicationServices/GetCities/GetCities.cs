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
    public class GetCities : IGetCities
    {
        private readonly IUnitOfWork unit;

        public GetCities(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetCitiesResultDto Execute(GetCitiesDto dto)
        {
            return new GetCitiesResultDto
            {
                Object = unit.City.GetByProvinceId(dto),
                Status = true
            };
        }
    }

    
}
