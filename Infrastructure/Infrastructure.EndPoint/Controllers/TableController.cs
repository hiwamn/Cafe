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

    public class TableController : SimpleController
    {
        private readonly IAddProductToTable addProductToTable;
        private readonly IGetReserved getReserved;
        private readonly IGetTablesMessagesByPage getTablesMessagesByPage;
        private readonly IChangeReserveStatus changeReserveStatus;
        private readonly IAddGameToTable addGameToTable;
        private readonly IEditTableBill editTableBill;

        public TableController(
            IAddProductToTable addProductToTable,
            IGetReserved getReserved,
            IGetTablesMessagesByPage getTablesMessagesByPage,
            IChangeReserveStatus changeReserveStatus,
            IAddGameToTable addGameToTable,
            IEditTableBill editTableBill
            )
        {
            this.addProductToTable = addProductToTable;
            this.getReserved = getReserved;
            this.getTablesMessagesByPage = getTablesMessagesByPage;
            this.changeReserveStatus = changeReserveStatus;
            this.addGameToTable = addGameToTable;
            this.editTableBill = editTableBill;
        }

        [HttpPost]
        public ActionResult<ApiResult> AddProductToTable([FromBody] AddProductToTableDto dto)
        {
            return addProductToTable.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetTablesReserveResultDto> GetReserved()
        {
            return getReserved.Execute();
        }
        [HttpGet]
        public ActionResult<GetTablesMessagesResultDto> GetTablesMessagesByPage([FromQuery] GetTablesMessagesDto dto)
        {
            return getTablesMessagesByPage.Execute(dto);
        }
        [HttpPost]
        public ActionResult<BaseApiResult> ChangeReserveStatus([FromBody] ChangeReserveStatusDto dto)
        {
            return changeReserveStatus.Execute(dto);
        }
        [HttpPost]
        public ActionResult<AddGameToTableResultDto> AddGameToTable([FromBody] AddGameToTableDto dto)
        {
            return addGameToTable.Execute(dto);
        }
        [HttpPost]
        public ActionResult<EditTableBillResultDto> EditTableBill([FromBody] EditTableBillDto dto)
        {
            return editTableBill.Execute(dto);
        }

    }
}
