using Core.ApplicationServices;
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

    public class MessageController : SimpleController
    {
        private readonly IAddMessage addMessage;
        private readonly IGetAdminMessagesByPage getAdminMessagesByPage;

        public MessageController(
            IAddMessage addMessage,
            IGetAdminMessagesByPage getAdminMessagesByPage
            )
        {
            this.addMessage = addMessage;
            this.getAdminMessagesByPage = getAdminMessagesByPage;
        }
        [HttpPost]
        public ActionResult<ApiResult> AddMessage([FromBody] AddMessageDto dto)
        {
            return addMessage.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetAdminMessagesByPageResultDto> GetAdminMessagesByPage([FromQuery] GetAdminMessagesByPageDto dto)
        {
            return getAdminMessagesByPage.Execute(dto);
        }



    }
}
