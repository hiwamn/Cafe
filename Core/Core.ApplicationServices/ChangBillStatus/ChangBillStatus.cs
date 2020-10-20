using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class ChangBillStatus : IChangBillStatus
    {
        private readonly IUnitOfWork unit;
        private readonly ISendAccountantNotification sendAccountantNotification;

        public ChangBillStatus(IUnitOfWork unit,ISendAccountantNotification sendAccountantNotification)
        {
            this.unit = unit;
            this.sendAccountantNotification = sendAccountantNotification;
        }

        public BaseApiResult Execute(ChangBillStatusDto dto)
        {
            BaseApiResult result = new BaseApiResult { Message = Messages.BillNotFound };

            var bill = unit.Bills.Get(dto.Id);
            if (bill.UserId != null)
            {
                sendAccountantNotification.Execute(new SendAccountantNotificationDto { Type = DtoBuilder.MapBillStatusToNotification(dto.StatusId.ToInt()), TableId = dto.TableId });                
            }
            if (bill != null)
            {
                var now = DateTime.Now.ToUnix();
                bill.EndedAt = now;

                bill.UpdatedAt = now;
                bill.StatusId = dto.StatusId.ToInt();

                if (dto.StatusId != BillStatus.StaffRelease)
                {
                    Table tbl = unit.Tables.Get(dto.TableId);
                    tbl.StatusId = TableStatus.Free.ToInt();
                    TableReserve tblReserve = unit.TableReserve.Get(bill.TableReserveId);
                    tblReserve.StatusId = TableStatus.Free.ToInt();
                }
                else
                {
                    BillGames billGame = unit.BillGames.GetLast(bill.Id);
                    if (billGame != null)
                        billGame.To = now;
                }

                if (dto.StatusId == BillStatus.CashPaid)
                {
                    unit.Transactions.Add(new Transaction
                    {
                        Amount = bill.Paid,
                        CreatedAt = Agent.Now,
                        UserId = bill.UserId,
                        TransactionCategoryId = TransactionCategories.Cash.ToInt(),
                        IsSuccessful = true,
                        BillId = bill.Id
                    });
                }
                unit.Complete();
                result.Message = Messages.BillStatusIsChanged;
                result.Status = true;
            }
            return result;
        }
    }
}
