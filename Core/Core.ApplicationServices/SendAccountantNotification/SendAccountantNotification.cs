using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class SendAccountantNotification : ISendAccountantNotification
    {

        private readonly IUnitOfWork unit;

        public SendAccountantNotification(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public BaseApiResult Execute(SendAccountantNotificationDto dto)
        {

            BaseApiResult result = new BaseApiResult { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();

            List<User> users = unit.Device.GetAccountants();
            Table tbl = unit.Tables.Get(dto.TableId);
            string message = DtoBuilder.GetTableMessageText(dto.Type, tbl);
            foreach (var item in users)
            {                
                Api.PostRequest(Agent.ToJson(new SendNotificationDto { UserId = item.Id, Text = message, Title = "آلارم میز", Status = 1 }), $"{AdminSettings.StaffApi}/Notification/SendNotification", null, null);
                Thread.Sleep(100);
            }

            unit.TableMessage.Add(new TableMessage { CreatedAt = now,TableId = dto.TableId,Text = message,Type = dto.Type});
            unit.Complete();

            return result;
        }
    }
}
