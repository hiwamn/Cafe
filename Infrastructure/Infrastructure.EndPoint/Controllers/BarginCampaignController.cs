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

    public class BarginCampaignController : SimpleController
    {
        private readonly IGetBarginCampaignByPage getBarginCampaignByPage;
        private readonly IGetBarginCampaignById getBarginCampaignById;
        private readonly IJoinBarginCampaign joinBarginCampaign;
        private readonly IEditBarginCampaign editBarginCampaign;

        public BarginCampaignController(
            IGetBarginCampaignByPage getBarginCampaignByPage,
            IGetBarginCampaignById getBarginCampaignById,
            IJoinBarginCampaign joinBarginCampaign,
            IEditBarginCampaign editBarginCampaign
            )
        {
            this.getBarginCampaignByPage = getBarginCampaignByPage;
            this.getBarginCampaignById = getBarginCampaignById;
            this.joinBarginCampaign = joinBarginCampaign;
            this.editBarginCampaign = editBarginCampaign;
        }

        [HttpGet]
        public ActionResult<GetBarginCampaignByPageResultDto> GetBarginCampaignByPage([FromQuery] GetBarginCampaignByPageDto dto)
        {
            return getBarginCampaignByPage.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetBarginCampaignByIdResultDto> GetBarginCampaignById([FromQuery] BaseByIdDto dto)
        {
            return getBarginCampaignById.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> JoinBarginCampaign([FromBody] JoinBarginCampaignDto dto)
        {
            return joinBarginCampaign.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> EditBarginCampaign([FromBody] EditBarginCampaignDto dto)
        {
            return editBarginCampaign.Execute(dto);
        }


    }
}
