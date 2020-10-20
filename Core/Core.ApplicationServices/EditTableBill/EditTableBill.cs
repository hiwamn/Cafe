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
    public class EditTableBill : IEditTableBill
    {

        private readonly IUnitOfWork unit;
        private readonly IGetUserById getUserById;

        public EditTableBill(IUnitOfWork unit,IGetUserById getUserById)
        {
            this.unit = unit;
            this.getUserById = getUserById;
        }
        public EditTableBillResultDto Execute(EditTableBillDto dto)
        {
            EditTableBillResultDto result = new EditTableBillResultDto
            { 
                Status = true, 
                Message = Messages.Success 
            };
            var now = DateTime.Now.ToUnix();
            var tableBill = unit.Bills.GetByTable(dto.TableId);
            tableBill.PeopleCount = dto.PeopleCount;
            tableBill.Description = dto.Description;
            unit.Complete();
            return result;
        }
    }
}
