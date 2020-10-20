using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class ChangeReserveStatus : IChangeReserveStatus
    {
        private readonly IUnitOfWork unit;

        public ChangeReserveStatus(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public BaseApiResult Execute(ChangeReserveStatusDto dto)
        {
            BaseApiResult result = new BaseApiResult { Status = true, Message = "کاربر یافت نشد" };

            TableReserve res = unit.TableReserve.Get(dto.Id);
            res.StatusId = dto.Status;
            res.Description = dto.Description;
            res.Time = dto.Time;
            unit.Complete();
            return result;
        }
    }
}
