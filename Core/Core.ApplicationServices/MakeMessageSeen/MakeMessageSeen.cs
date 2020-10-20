using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class MakeMessageSeen : IMakeMessageSeen
    {

        private readonly IUnitOfWork unit;

        public MakeMessageSeen(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public BaseApiResult Execute(MakeMessageSeenDto dto)
        {

            BaseApiResult result = new BaseApiResult { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();
            var mess = unit.Message.Get(dto.MessageId);
            mess.IsSeen = true;
            unit.Complete();


            return result;
        }
    }
}
