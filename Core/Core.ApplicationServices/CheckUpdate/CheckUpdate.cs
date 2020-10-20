using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class CheckUpdate : ICheckUpdate
    {
        private readonly IUnitOfWork unit;

        public CheckUpdate(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public UpdateDto Execute(string Version)
        {
            UpdateDto updateDto = new UpdateDto { Message = Messages.NoUpdateRaw};
            Update up = unit.Update.GetUpdate(Version);
            if (up != null)
            {
                updateDto.Object = up;
                updateDto.Status = true;
            }
            return updateDto;
        }
    }
}
