using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class AddSlider : IAddSlider
    {

        private readonly IUnitOfWork unit;

        public AddSlider(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(AddSliderDto dto)
        {
            ApiResult result = new ApiResult { Status = true,Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();

            
            Slider slider = new Slider
            {
                CreatedAt = now,
                DocumentId = dto.ImageId
            };
            unit.Slider.Add(slider);
            unit.Complete();            
            return result;
        }
    }
}
