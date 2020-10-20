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

    public class StaffController : SimpleController
    {
        private readonly IGetStaffs getStaffs;
        private readonly IRegisterStaff registerStaff;
        private readonly IDeleteStaff deleteStaff;
        private readonly IGiveRewardToStaff giveRewardToStaff;
        private readonly IAddBillForStaff addBillForStaff;
        private readonly IAddBillItemForStaff addBillItemForStaff;
        private readonly IGetStaffById getStaffById;

        public StaffController(
            IGetStaffs getStaffs,
            IRegisterStaff registerStaff,
            IDeleteStaff deleteStaff,
            IGiveRewardToStaff giveRewardToStaff,
            IAddBillForStaff addBillForStaff,
            IAddBillItemForStaff addBillItemForStaff,
            IGetStaffById getStaffById
            )
        {
            this.getStaffs = getStaffs;
            this.registerStaff = registerStaff;
            this.deleteStaff = deleteStaff;
            this.giveRewardToStaff = giveRewardToStaff;
            this.addBillForStaff = addBillForStaff;
            this.addBillItemForStaff = addBillItemForStaff;
            this.getStaffById = getStaffById;
        }

        [HttpGet]
        public ActionResult<GetStaffsResultDto> GetStaffs([FromQuery] GetStaffsDto dto)
        {
            return getStaffs.Execute(dto);
        }
        [HttpPost]
        public ActionResult<BaseApiResult> RegisterStaff([FromBody] RegisterStaffDto dto)
        {
            return registerStaff.Execute(dto);
        }
        [HttpPost]
        public ActionResult<BaseApiResult> DeleteStaff([FromBody] BaseByUserDto dto)
        {
            return deleteStaff.Execute(dto);
        }
        [HttpPost]
        public ActionResult<BaseApiResult> GiveRewardToStaff([FromBody] GiveRewardToStaffDto dto)
        {
            return giveRewardToStaff.Execute(dto);
        }
        [HttpPost]
        public ActionResult<AddBillForStaffResultDto> AddBillForStaff([FromBody] AddBillForStaffDto dto)
        {
            return addBillForStaff.Execute(dto);
        }
        [HttpPost]
        public ActionResult<AddBillItemForStaffResultDto> AddBillItemForStaff([FromBody] AddBillItemDto dto)
        {
            return addBillItemForStaff.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetUserByIdResultDto> GetStaffById([FromQuery] GetUserByIdDto dto)
        {
            return getStaffById.Execute(dto);
        }


    }
}
