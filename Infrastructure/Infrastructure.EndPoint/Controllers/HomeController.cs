using Core.ApplicationServices;
using Core.Entities.Dto;
using Infrastructure.EF;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.Tools.Notification;

namespace Infrastructure.EndPoint.Controllers
{
    public class HomeController : SimpleController
    {
        private readonly INotification notification;
        private readonly IGetSliders getSliders;

        public HomeController(
            INotification notification,
            IGetSliders getSliders
            )
        {
            this.notification = notification;
            this.getSliders = getSliders;
        }
        [HttpGet]


        public async Task<ActionResult<string>> Index([FromQuery]EmailBox dto)
        {
            await notification.SendAsync(dto.Text, dto.Email);
            return "salam";
        }
        
        [HttpGet]
        public ActionResult<GetSlidersResultDto> GetSliders()
        {
            return getSliders.Execute();
        }


        
    }

    public class EmailBox
    {
        public string Text { get; set; }
        public string Email { get; set; }
    }
}
