using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Enums;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class CalculatePrice : ICalculatePrice
    {

        private readonly IUnitOfWork unit;
        public List<Bargin> _bar { get; set; }
        public List<Discount> _dis { get; set; }

        public CalculatePrice(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public CalculatePriceResultDto Execute(CalculatePriceDto dto)
        {
            CalculatePriceResultDto result = new CalculatePriceResultDto { Status = true, Message = Messages.Success, };

            
            Bill bill = unit.Bills.GetByDetaill(dto.BillId);
            
             _dis = bill.User?.Discount.Where(p => p.To > Agent.Now).Select(p => new Discount { Value = p.Percent }).ToList();
             _bar = bill.User?.BarginUsers.
                Where(p => p.BarginCampaign.StatusId == Enums.EntityStatus.Active.ToInt()).
                Select(p => new Bargin { 
                    GameId = p.BarginCampaign.GameTypeId.Value,
                    //ProductId = p.BarginCampaign.ProductId.Value, 
                    Type = p.BarginCampaign.BarginTypeId, 
                    Value = p.BarginCampaign.BarginTypeId }).ToList();

            int price = 0;
            if (bill.BillItem != null)
                foreach (var item in bill.BillItem)
                    price += CalculateProducts(item);
            if (bill.BillGames != null)
                foreach (var item in bill.BillGames)
                    price += CalculateGames(item);

            if (bill.UserId != null)
            {
                var lastDiscount = unit.LastDiscounts.GetLastByUser(bill.UserId);
                
            }
            result.Object = price;
            return result;
        }

        private int CalculateGames(BillGames item)
        {
            var time = (item.To.ToDate() - item.From.ToDate()).TotalMinutes / 60.0;
            double mainPrice = item.Count * (item.UnitPriceFirstHour + ((time - 1) <= 0 ? 0 : (time - 1) * item.UnitPriceOtherHour));

            if (_bar != null)
                foreach (var bar in _bar)
                {
                    if (bar.GameId == item.GameTypeId)
                    {
                        if (bar.Type == BarginTypes.Fixed.ToInt())
                            mainPrice -= bar.Value;
                        else
                            mainPrice -= mainPrice * bar.Value / 100.00;
                    }
                }

            return (int)mainPrice;
        }

        private int CalculateProducts(BillItem item)
        {
            int mainPrice = item.Count * item.UnitPrice;
            if (_dis != null)
                foreach (var dis in _dis)
                    mainPrice = mainPrice - dis.Value;
            return mainPrice;
        }
    }



}
