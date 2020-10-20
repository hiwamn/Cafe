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
        private readonly IMakeMessageSeen makeMessageSeen;

        public MessageController(
            IAddMessage addMessage,
            IGetAdminMessagesByPage getAdminMessagesByPage,
            IMakeMessageSeen makeMessageSeen
            )
        {
            this.addMessage = addMessage;
            this.getAdminMessagesByPage = getAdminMessagesByPage;
            this.makeMessageSeen = makeMessageSeen;
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
        [HttpPost]
        public ActionResult<BaseApiResult> MakeMessageSeen([FromBody] MakeMessageSeenDto dto)
        {
            return makeMessageSeen.Execute(dto);
        }



    }
}
