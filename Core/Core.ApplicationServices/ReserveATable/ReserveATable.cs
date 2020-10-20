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
    public class ReserveATable : IReserveATable
    {

        private readonly IUnitOfWork unit;
        private readonly IGetUserById getUserById;

        public ReserveATable(IUnitOfWork unit,IGetUserById getUserById)
        {
            this.unit = unit;
            this.getUserById = getUserById;
        }
        public ReserveATableResultDto Execute(ReserveATableDto dto)
        {
            ReserveATableResultDto result = new ReserveATableResultDto 
            { 
                Status = false, 
                Message = Messages.InvalidBarCode 
            };
            var now = DateTime.Now.ToUnix();

            if (dto.BarCode != null && dto.BarCode != "")
            {
                Guid? userId = null;
                Guid? promoterId = null;
                Table tbl = unit.Tables.GetByBarCode(dto.BarCode);
                tbl.StatusId = TableStatus.Taken.ToInt();
                if (dto.IsPromoter)
                {
                    promoterId = dto.UserId;
                }
                else
                    userId = dto.UserId;
                if (tbl != null)
                {
                    TableReserve tableReserve = unit.TableReserve.GetByTableId(tbl.Id);
                    if (tableReserve == null)
                    {
                        TableReserve tr = new TableReserve
                        {
                            CreatedAt = now,
                            UserId = userId,
                            StatusId = TableStatus.Taken.ToInt(),
                            TableId = tbl.Id,
                            Time = dto.Time != 0 ? dto.Time : Agent.Now,
                            Bill = new List<Bill> { new Bill { CreatedAt = now, StatusId = BillStatus.Pending.ToInt(), UpdatedAt = now, UserId = userId, PromoterId = promoterId,PeopleCount = dto.PeopleCount,Description = dto.Description } },
                            Description = dto.Description
                        };
                        unit.TableReserve.Add(tr);
                        
                    }
                    else if (tableReserve != null|| tableReserve.Bill.Any(p=>p.StatusId == BillStatus.Pending.ToInt()))
                    {
                        if(promoterId != null)
                            tableReserve.Bill.FirstOrDefault().PromoterId = promoterId;
                        else
                            tableReserve.Bill.FirstOrDefault().UserId = userId;
                        if(dto.Description !=null && dto.Description !="")
                            tableReserve.Description = dto.Description;
                        if(dto.PeopleCount !=0)
                            tableReserve.Bill.FirstOrDefault().PeopleCount = dto.PeopleCount;
                    }

                    unit.Complete();
                    result.Message = Messages.OK;
                    result.Status = true;
                }
                result.Object = getUserById.Execute(new GetUserByIdDto { UserId = dto.UserId }).Object;

            }
            else
            {
                TableReserve tr = new TableReserve
                {
                    CreatedAt = now,
                    UserId = dto.UserId,
                    StatusId = TableStatus.Reserved.ToInt(),
                    TableId = null,
                    Time = dto.Time != 0 ? dto.Time : Agent.Now
                };
                unit.TableReserve.Add(tr);
                unit.Complete();
                result.Status = true;
                result.Message = Messages.Success;
            }
            return result;
        }
    }
}
