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
    public class GetSliders : IGetSliders
    {
        private readonly IUnitOfWork unit;

        public GetSliders(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetSlidersResultDto Execute()
        {
            return new GetSlidersResultDto
            {
                Object = unit.Slider.GetIncludeDocument(),
                Status = true
            };
        }
    }

    
}
