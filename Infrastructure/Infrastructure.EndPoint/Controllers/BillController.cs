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

    public class BillController : SimpleController
    {
        private readonly IGetBillsByPage getBillsByPage;
        private readonly IGetBillById getBillById;
        private readonly IChangBillStatus changBillStatus;
        private readonly IPayBill payBill;
        private readonly IPayFromWallet payFromWallet;

        public BillController(
            IGetBillsByPage getBillsByPage,
            IGetBillById getBillById,
            IChangBillStatus changBillStatus,
            IPayBill payBill,
            IPayFromWallet payFromWallet
            )
        {
            this.getBillsByPage = getBillsByPage;
            this.getBillById = getBillById;
            this.changBillStatus = changBillStatus;
            this.payBill = payBill;
            this.payFromWallet = payFromWallet;
        }

        [HttpGet]
        public ActionResult<GetBillsByPageResultDto> GetBillsByPage([FromQuery] BaseByUserPageBillDto dto)
        {
            return getBillsByPage.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetBillByIdResultDto> GetBillById([FromQuery] BaseByIdDto dto)
        {
            return getBillById.Execute(dto);
        }
        [HttpPost]
        public ActionResult<BaseApiResult> ChangBillStatus([FromBody] ChangBillStatusDto dto)
        {
            return changBillStatus.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> PayBill([FromBody] PayBillDto dto)
        {
            return payBill.Execute(dto);
        }
        [HttpPost]
        public ActionResult<BaseApiResult> PayFromWallet([FromBody] PayFromWalletDto dto)
        {
            return payFromWallet.Execute(dto);
        }


    }
}
