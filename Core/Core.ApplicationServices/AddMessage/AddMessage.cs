using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class AddMessage : IAddMessage
    {

        private readonly IUnitOfWork unit;

        public AddMessage(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(AddMessageDto dto)
        {
            ApiResult result = new ApiResult { Status = true,Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();

            
            Message mess = new Message
            {
                CreatedAt = now,
                UserId = dto.UserId,
                Text = dto.Text,
                IsFromAdmin = dto.IsFromAdmin

            };
            unit.Message.Add(mess);
            unit.Complete();
            result.Object = mess;
            return result;
        }
    }
}
