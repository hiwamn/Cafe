using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class DeleteSlider : IDeleteSlider
    {

        private readonly IUnitOfWork unit;

        public DeleteSlider(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(BaseByIdDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.IsUsed };

            var slider = unit.Slider.Get(dto.Id);
            unit.Slider.Remove(slider);
            unit.Complete();

            return result;
        }
    }
}
