using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class PayBill : IPayBill
    {

        private readonly IUnitOfWork unit;

        public PayBill(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(PayBillDto dto)
        {
            ApiResult result = new ApiResult { Status = false, Message = Messages.AlreadyJoined, };
            var now = DateTime.Now.ToUnix();
            BillDto bill = unit.Bills.GetBillById(new BaseByIdDto { Id = dto.BillId });
            Bill b = unit.Bills.Get(dto.BillId);
            b.UpdatedAt = now;
            b.StatusId = dto.StatusId;
            Table tbl = unit.Tables.Get(bill.Table.Id);
            
            tbl.StatusId = TableStatus.Free.ToInt();
            TableReserve tblReserve = unit.TableReserve.Get(b.TableReserveId);
          
            tblReserve.StatusId = TableStatus.Free.ToInt();
            unit.Complete();
            return result;
        }
    }
}
