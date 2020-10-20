using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class SendNotification : ISendNotification
    {

        private readonly IUnitOfWork unit;
        private readonly IFireBase fireBase;

        public SendNotification(IUnitOfWork unit,IFireBase fireBase)
        {
            this.unit = unit;
            this.fireBase = fireBase;
        }
        public ApiResult Execute(SendNotificationDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();

            List<string> devices = unit.Device.GetSomeDevices(dto).Select(p=>p.PushId).ToList();
            fireBase.SendNotification(devices, new FCMObject { notification = new Not { title = dto.Title, body = dto.Text } } , null);
            unit.Complete();            
            return result;
        }
    }
}
