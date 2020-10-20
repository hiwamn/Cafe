using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Domain.Contract;
using Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.EF.Services
{
    public class DeviceRepository : Repository<Device>, IDeviceRepository
    {
        private readonly IContext ctx;

        public DeviceRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public List<User> GetAccountants()
        {
            return ctx.Users.Include(p => p.UserRole).Where(p => p.UserRole.Any(q => q.RoleId == UserType.Accountant.ToInt())).ToList();
        }

        public List<Device> GetSomeDevices(SendNotificationDto dto)
        {
            return ctx.Devices.Include(p=>p.User).Where(p => (dto.UserId == null || dto.UserId == p.UserId) &&
            (dto.Status == 0 || dto.Status == p.User.Status)
            ).ToList();
        }

        public bool IsExist(Guid userId, string deviceId)
        {
            return ctx.Devices.Any(p=>p.UserId == userId && p.PushId == deviceId);
        }

    }
}
