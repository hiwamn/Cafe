using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Domain.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.EF.Services
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        private readonly IContext ctx;

        public NotificationRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }
    }
}
