using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Domain.Contract;
using Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Utility;

namespace Infrastructure.EF.Services
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IContext ctx;

        public UserRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public User GetByMobile(string mobile)
        {
            return ctx.Users.Where(p => p.Mobile == mobile).
                Include(p=>p.UserRole).
                Include(p => p.ProfileImage).Include(p=>p.Transaction).
                //Include(p => p.Bill).ThenInclude(p => p.User).ThenInclude(p => p.ProfileImage).
                Include(p => p.Transaction).
                Include(p => p.Bill).ThenInclude(p => p.Promoter).ThenInclude(p => p.ProfileImage).
                //Include(p => p.Bill).ThenInclude(p => p.User).ThenInclude(p => p.Transaction).
                Include(p => p.Bill).ThenInclude(p => p.TableReserve).ThenInclude(p => p.Table).
                Include(p => p.Bill).ThenInclude(p => p.BillGames).ThenInclude(p => p.GameType).
                Include(p => p.Bill).ThenInclude(p => p.BillItem).ThenInclude(p => p.Product).ThenInclude(p => p.ProductImages).
                FirstOrDefault();
        }

        public User GetByEmailIncludingRoles(string email)
        {
            return ctx.Users.Where(p => p.Email == email)
                .Include(p => p.ProfileImage).Include(p => p.UserRole).FirstOrDefault();
        }
        public User GetByMobileIncludingRoles(string mobile)
        {
            return ctx.Users.Where(p => p.Mobile == mobile)
                .Include(p => p.ProfileImage).Include(p => p.UserRole).FirstOrDefault();
        }

       

        public GetUsersByPageResultDto GetUsersByPage(GetUsersByPageDto dto)
        {
            bool nameCheck = dto.Name == null || dto.Name == "";
            bool familyNameCheck = dto.FamilyName == null || dto.FamilyName == "";
            bool mobileCheck = dto.Mobile == null || dto.Mobile == "";
            List<User> users = ctx.Users.
                Where(p=>
                (nameCheck || p.Name.Contains(dto.Name))&&
                (familyNameCheck|| p.FamilyName.Contains(dto.FamilyName))&&
                (dto.Status == 0|| p.Status == dto.Status)&&
                (mobileCheck || p.Mobile.Contains(dto.Mobile))
                ).
                OrderByDescending(p => p.CreatedAt).                
                Include(p => p.ProfileImage).
                Include(p=>p.Transaction).                
                ToList();
            var res = users.
                Skip((dto.PageNo - 1) * AdminSettings.Block).
                Take(AdminSettings.Block).
                Select(p => DtoBuilder.CreateUserDto(p)).ToList();
            return new GetUsersByPageResultDto
            {
                Object = res,
                Status = true,
                Page = new PageDto
                {
                    PageNo = dto.PageNo,
                    CurrentCount = res.Count,
                    TotalCount = users.Count
                }
            };
        }

        public bool IsExistByEmail(string Email)
        {
            return ctx.Users.Any(p => p.Email == Email);
        }

        public bool IsExistByMobile(SendActiveCodeDto dto)
        {
            return ctx.Users.Any(p => p.Mobile == dto.Mobile && p.UserRole.FirstOrDefault(q => q.RoleId == dto.RoleId) != null);
        }

        public List<UserShortDto> SearchPeople(SearchPeopleDto dto)
        {
            return ctx.Users.Include(p => p.ProfileImage).
                Where(p=>
                p.Id != dto.UserId &&
                (
                dto.Keyword == null || 
                dto.Keyword == "" || 
                p.Name.Contains(dto.Keyword) || 
                p.FamilyName.Contains(dto.Keyword)||
                p.Mobile.Contains(dto.Keyword) //|| 
                //$"{p.Name} {p.FamilyName}".ToString().Contains(dto.Keyword)
                )
                ).AsEnumerable().ToList().
                Select(p => DtoBuilder.CreateShortUserDto(p)).
                ToList();
        }

        public GetUserByIdResultDto GetUserById(GetUserByIdDto dto)
        {
            var user = ctx.Users.Where(p => p.Id == dto.UserId).
                Include(p => p.ProfileImage).
                Include(p => p.UserRole).
                Include(p => p.Transaction).
                Include(p => p.TableReserve).ThenInclude(p=>p.Table).
                Include(p => p.TableReserve).ThenInclude(p=>p.Bill).ThenInclude(p=>p.BillItem).ThenInclude(p=>p.Product).
                Include(p => p.TableReserve).ThenInclude(p=>p.Bill).ThenInclude(p=>p.BillGames).ThenInclude(p=>p.GameType).
                Include(p => p.TableReserve).ThenInclude(p=>p.Bill).ThenInclude(p=>p.Promoter).ThenInclude(p=>p.ProfileImage).
                Select(p=>DtoBuilder.CreateGetByIdDto(p)).FirstOrDefault();
            return new GetUserByIdResultDto
            {
                Object = user,
                Status = true
            };
        }

        public GetStaffsResultDto GetStaffs(GetStaffsDto dto)
        {
            var res = ctx.Users.Include(p=>p.UserRole).Where(p => p.UserRole.Any(p=>p.RoleId == UserType.Staff.ToInt())).
                Include(p => p.ProfileImage).Include(p => p.Transaction).
                Select(p=>DtoBuilder.CreateUserDto(p)).ToList();
            return new GetStaffsResultDto
            {
                Status = true,
                Object = res
            };
        }

        public User GetByDetail(BaseByUserDto dto)
        {
            return ctx.Users.Where(p => p.Id == dto.UserId).
                Include(p => p.UserRole).
                Include(p => p.Bill).ThenInclude(p => p.BillItem).
                Include(p => p.Bill).ThenInclude(p => p.BillGames).
                ToList().FirstOrDefault();
        }

        public List<User> GetAllIncludeRoles()
        {
            return ctx.Users.Include(p => p.UserRole).ToList();
        }

        public GetUsersTimeByPageResultDto GetUsersTimeByPage(GetUsersTimeByPageDto dto)
        {
            //bool nameCheck = dto.Name == null || dto.Name == "";
            //bool familyNameCheck = dto.FamilyName == null || dto.FamilyName == "";
            //bool mobileCheck = dto.Mobile == null || dto.Mobile == "";
            List<UserLastVisitTimeDto> users = ctx.Users.Include(p => p.Bill).                
                //Where(p =>
                //(nameCheck || p.Name.Contains(dto.Name)) &&
                //(familyNameCheck || p.FamilyName.Contains(dto.FamilyName)) &&
                //(dto.Status == 0 || p.Status == dto.Status) &&
                //(mobileCheck || p.Mobile.Contains(dto.Mobile))
                //).                
                Include(p => p.ProfileImage).
                //Include(p => p.Transaction).
                ToList().
                Select(p=>DtoBuilder.CreateUserLastVisitTimeDto(p)).
                OrderByDescending(p=>p.Time).
                Skip((dto.PageNo - 1) * AdminSettings.Block).
                Take(AdminSettings.Block).
                ToList();            
            return new GetUsersTimeByPageResultDto
            {
                Object = users,
                Status = true,
                Page = new PageDto
                {
                    PageNo = dto.PageNo,
                    CurrentCount = users.Count,
                    TotalCount = ctx.Users.Count()
                }
            };
        }

        public GetUserByIdResultDto GetStaffById(GetUserByIdDto dto)
        {
            var user = ctx.Users.Where(p => p.Id == dto.UserId).
                Include(p => p.UserRole).
                Include(p => p.ProfileImage).
                Include(p => p.Transaction).
                Include(p => p.Bill).ThenInclude(p => p.BillItem).ThenInclude(p => p.Product).
                Include(p => p.Bill).ThenInclude(p => p.BillGames).ThenInclude(p => p.GameType).                
                Select(p => DtoBuilder.CreateStaffDto(p)).FirstOrDefault();
            return new GetUserByIdResultDto
            {
                Object = user,
                Status = true
            };
        }
    }
}
