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

    public class SettingController : SimpleController
    {
        private readonly IGetSetting getSetting;
        private readonly IUpdateSetting updateSetting;

        public SettingController(
            IGetSetting getSetting,
            IUpdateSetting updateSetting

            )
        {
            this.getSetting = getSetting;
            this.updateSetting = updateSetting;
        }

        [HttpGet]
        public ActionResult<GetSettingResultDto> GetSetting()
        {
            return getSetting.Execute();
        }
        [HttpPost]
        public ActionResult<BaseApiResult> UpdateSetting([FromBody] SettingDto dto)
        {
            return updateSetting.Execute(dto);
        }



    }
}
