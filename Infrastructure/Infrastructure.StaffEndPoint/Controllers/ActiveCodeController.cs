using Core.ApplicationServices;
using Core.Contracts;
using Core.Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.EndPoint.Controllers
{
    public class ActiveCodeController : SimpleController
    {
        private readonly IUnitOfWork unit;
        private readonly ISendActiveCode sendActive;
        private readonly ICheckActiveCode checkActiveCode;

        public ActiveCodeController(IUnitOfWork unit, ISendActiveCode sendActive, ICheckActiveCode checkActiveCode)
        {
            this.unit = unit;
            this.sendActive = sendActive;
            this.checkActiveCode = checkActiveCode;
        }


        [HttpPost]
        public ActionResult<BaseApiResult> SendActiveCode([FromBody] SendActiveCodeDto dto)
        {
            return sendActive.Execute(dto);
        }

        [HttpPost]
        public ActionResult<CheckActiveCodeResultDto> CheckActiveCode([FromBody] CheckActiveCodeDto dto)
        {
            return checkActiveCode.Execute(dto);
        }



    }
}
