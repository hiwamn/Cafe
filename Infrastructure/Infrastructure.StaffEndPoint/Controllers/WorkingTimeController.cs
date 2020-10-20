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

    public class WorkingTimeController : SimpleController
    {
        private readonly IGetAdminDailyWorkingTime getAdminDailyWorkingTime;
        private readonly IAcceptWorkingTime acceptWorkingTime;
        private readonly IGetAdminRegisteredDailyWorkingTime getAdminRegisteredDailyWorkingTime;
        private readonly IEditWorkingTime editWorkingTime;
        private readonly IAcceptAllWorkingTime acceptAllWorkingTime;

        public WorkingTimeController(
            IGetAdminDailyWorkingTime getAdminDailyWorkingTime,
            IAcceptWorkingTime acceptWorkingTime,
            IGetAdminRegisteredDailyWorkingTime getAdminRegisteredDailyWorkingTime,
            IEditWorkingTime editWorkingTime,
            IAcceptAllWorkingTime acceptAllWorkingTime
            )
        {
            this.getAdminDailyWorkingTime = getAdminDailyWorkingTime;
            this.acceptWorkingTime = acceptWorkingTime;
            this.getAdminRegisteredDailyWorkingTime = getAdminRegisteredDailyWorkingTime;
            this.editWorkingTime = editWorkingTime;
            this.acceptAllWorkingTime = acceptAllWorkingTime;
        }

        [HttpGet]
        public ActionResult<GetAdminDailyWorkingTimeResultDto> GetAdminDailyWorkingTime([FromQuery] GetAdminDailyWorkingTimeDto dto)
        {
            return getAdminDailyWorkingTime.Execute(dto);
        }
        [HttpPost]
        public ActionResult<BaseApiResult> AcceptWorkingTime([FromBody] AcceptWorkingTimeDto dto)
        {
            return acceptWorkingTime.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetAdminRegisteredDailyWorkingTimeResultDto> GetAdminRegisteredDailyWorkingTime([FromQuery] GetAdminRegisteredDailyWorkingTimeDto dto)
        {
            return getAdminRegisteredDailyWorkingTime.Execute(dto);
        }
        [HttpPost]
        public ActionResult<BaseApiResult> EditWorkingTime([FromBody] EditWorkingTimeDto dto)
        {
            return editWorkingTime.Execute(dto);
        }
        [HttpPost]
        public ActionResult<BaseApiResult> AcceptAllWorkingTime([FromBody] AcceptAllWorkingTimeDto dto)
        {
            return acceptAllWorkingTime.Execute(dto);
        }


    }
}
