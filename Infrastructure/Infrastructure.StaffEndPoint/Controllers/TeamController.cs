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

    public class TeamController : SimpleController
    {
        private readonly IAddTeam addTeam;
        private readonly IJoinTeam joinTeam;
        private readonly ILeftTeam leftTeam;
        private readonly IGetTeamsByPage getTeamsByPage;

        public TeamController(
            IAddTeam addTeam,
            IJoinTeam joinTeam,
            ILeftTeam leftTeam,
            IGetTeamsByPage getTeamsByPage
            )
        {
            this.addTeam = addTeam;
            this.joinTeam = joinTeam;
            this.leftTeam = leftTeam;
            this.getTeamsByPage = getTeamsByPage;
        }

        [HttpGet]
        public ActionResult<GetTeamsByPageResultDto> GetTeamsByPage([FromQuery] GetTeamsByPageDto dto)
        {
            return getTeamsByPage.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> AddTeam([FromBody] AddTeamDto dto)
        {
            return addTeam.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> LeftTeam([FromBody] LeftTeamDto dto)
        {
            return leftTeam.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> JoinTeam([FromBody] JoinTeamDto dto)
        {
            return joinTeam.Execute(dto);
        }


    }
}
