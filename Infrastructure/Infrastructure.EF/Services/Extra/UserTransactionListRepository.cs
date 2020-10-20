using Core.ApplicationServices;
using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Domain.Contract;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.EF.Services
{
    public class UserTransactionListRepository : Repository<UserTransactionList>, IUserTransactionListRepository
    {
        private readonly IContext ctx;

        public UserTransactionListRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public List<UserShortDto> GetUserTransactionPartners(BaseByUserDto dto)
        {
            return ctx.UserTransactionList.Where(p => p.UserId == dto.UserId).
                Include(p => p.Partner).ThenInclude(p=>p.ProfileImage).ToList().Select(p => DtoBuilder.CreateShortUserDto(p.Partner)).
                ToList();
        }

        public bool IsExist(AddUserToFriendsDto dto)
        {
            return ctx.UserTransactionList.Any(p=>p.UserId == dto.UserId && p.PartnerId == dto.PartnerId);
        }
    }
}
