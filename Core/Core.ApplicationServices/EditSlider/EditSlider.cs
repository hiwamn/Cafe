using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class EditSlider : IEditSlider
    {

        private readonly IUnitOfWork unit;

        public EditSlider(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(EditSliderDto dto)
        {
            ApiResult result = new ApiResult { Status = false, Message = Messages.IsUsed };
            var gt = unit.Slider.Get(dto.Id);
            gt.DocumentId = dto.ImageId;
            unit.Complete();
            return result;
        }
    }
}
