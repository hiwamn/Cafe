using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Core.Entities.Functions;
using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class AddBillForStaff : IAddBillForStaff
    {

        private readonly IUnitOfWork unit;

        public AddBillForStaff(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public AddBillForStaffResultDto Execute(AddBillForStaffDto dto)
        {
            AddBillForStaffResultDto result = new AddBillForStaffResultDto { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();

            Bill bi = new Bill
            {
                Description = dto.Description,
                CreatedAt = now,
                PeopleCount = 1,
                StatusId = BillStatus.Pending.ToInt(),
                UserId = dto.UserId
            };
            unit.Bills.Add(bi);
            unit.Complete();
            result.Object = DtoBuilder.CreateBillDto(bi);
            return result;
        }
    }
}
