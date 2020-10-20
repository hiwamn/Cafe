using Core.ApplicationServices;
using Core.Entities;
using Core.Entities.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.EndPoint.Controllers
{
    
    public class NotificationController : SimpleController
    {
        private readonly ICheckUpdate checkUpdate;
        private readonly ISendNotification sendNotification;

        public NotificationController(ISendNotification sendNotification)
        {
            this.sendNotification = sendNotification;
        }

        [HttpPost]        
        public ActionResult<ApiResult> SendNotification([FromBody] SendNotificationDto dto)
        {
            return sendNotification.Execute(dto);
        }
        

    }
}
