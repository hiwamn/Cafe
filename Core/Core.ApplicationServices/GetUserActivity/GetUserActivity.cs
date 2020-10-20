using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class GetUserActivity : IGetUserActivity
    {
        private readonly IUnitOfWork unit;

        public GetUserActivity(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetUserActivityResultDto Execute(GetUserActivityDto dto)
        {           
            User user = unit.Users.GetByDetail(dto);
            double totalhour = user.Bill.Sum(p =>
            (p.UpdatedAt.ToDate() - p.CreatedAt.ToDate()).TotalMinutes / 60.00
            );
            double totalbill =
                user.Bill.Sum(p => p.BillItem.Sum(q => q.Count * q.UnitPrice) +
                p.BillGames.Sum(q =>
                {
                    var time = (q.To.ToDate() - q.From.ToDate()).TotalMinutes / 60.0;
                    return Convert.ToInt64(q.Count * (q.UnitPriceFirstHour + ((time - 1) <= 0 ? 0 : (time - 1) * q.UnitPriceOtherHour)));
                }
                ));
            double gaming = 
                user.Bill.Sum(p => 
                p.BillGames.Sum(q=>(q.To.ToDate()- q.From.ToDate()).TotalMinutes/60.00)
                );
                    
            return new GetUserActivityResultDto
            {
                Status = true,
                Object = new GetUserActivityObject
                {
                    TotalHour = totalhour,
                    TotalBill = totalbill,
                    TotalGamingHour = gaming,
                    Activity = user.Bill.Select(p=>p.CreatedAt).ToList()
                }
            };
        }
    }

    
}
