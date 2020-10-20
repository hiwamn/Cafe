using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class AddGameToTable : IAddGameToTable
    {

        private readonly IUnitOfWork unit;
        private readonly IGetTables getTables;
        private readonly ICalculatePrice calculatePrice;
        private readonly ISendAccountantNotification sendAccountantNotification;

        public AddGameToTable(
            IUnitOfWork unit,
            IGetTables getTables,
            ICalculatePrice calculatePrice,
            ISendAccountantNotification sendAccountantNotification
            )
        {
            this.unit = unit;
            this.getTables = getTables;
            this.calculatePrice = calculatePrice;
            this.sendAccountantNotification = sendAccountantNotification;
        }
        public AddGameToTableResultDto Execute(AddGameToTableDto dto)
        {
            AddGameToTableResultDto result = new AddGameToTableResultDto { Status = true, Message = Messages.Success };
            var now = DateTime.Now.ToUnix();
            GameType prod = unit.GameTypes.Get(dto.GameTypeId);
            Bill bill = unit.Bills.GetByTable(dto.TableId);
            BillGames billGame = unit.BillGames.GetLast(bill.Id);
            if (billGame != null)
                billGame.To = now;
            BillGames billGames = new BillGames
            {
                BillId = bill.Id,
                Count = dto.Count,
                CreatedAt = now,
                Description = dto.Description,
                From = now,
                GameTypeId = dto.GameTypeId,
                UnitPriceFirstHour = prod.PricePerFirstHour,
                UnitPriceOtherHour = prod.PricePerOtherhour
            };
            unit.BillGames.Add(billGames);
            unit.Complete();
            if(dto.Type == TableMessageType.Decrease.ToInt() || dto.Type == TableMessageType.Increase.ToInt())
                sendAccountantNotification.Execute(new SendAccountantNotificationDto { Type = dto.Type, TableId = dto.TableId });
            bill.Paid = calculatePrice.Execute(new CalculatePriceDto { BillId = bill.Id }).Object;
            unit.Complete();
            result.Object = getTables.Execute().Object.FirstOrDefault(p=>p.Id == dto.TableId);
            return result;
        }
    }
}
