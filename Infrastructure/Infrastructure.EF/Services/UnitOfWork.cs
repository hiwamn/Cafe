using Core.Contracts;
using Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contract
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            IContext ctx,
            ICityRepository City,
        ICountryRepository Country,
        IProvinceRepository Province,
        IDocumentRepository Document,
        IActiveCodeRepository ActiveCode,
        IDeviceRepository Device,
        IEntityStatusRepository EntityStatus,
        INotificationRepository Notification,
        ISettingRepository Setting,
        IUpdateRepository Update,
        IRoleRepository Roles,
        IUserRepository Users,
        IUserRoleRepository UserRoles,
        IBarginCampaignRepository BarginCampaigns,
        IBarginTypeRepository BarginTypes,
        IEventAndLeagueRepository EventAndLeagues,
        IGameTypeRepository GameTypes,
        IGroupGameRepository GroupGames,
        IProductRepository Products,
        IProductImageRepository ProductImages,
        ITableRepository Tables,
        IBillRepository Bills,
        IBillItemRepository BillItems,
        ITransactionRepository Transactions,
        ITransactionCategoryRepository TransactionCategories,
        IBarginUsersRepository BarginUsers,
        IGroupGameUsersRepository GroupGameUsers,
        IRegisteredTableRepository RegisteredTable,
        ISliderRepository Slider,
        IUserTransactionListRepository UserTransactionList,
        ITableReserveRepository TableReserve,
        ITeamRepository Team,
        ITeamMemberRepository TeamMember,
        IEventUsersRepository EventUsers,
        IRegisteredTableUserCountRepository RegisteredTableUserCount,
        IMessageRepository Message,
        IBillGamesRepository BillGames,
        IProductRateRepository ProductRate,
        IWorkTimeRepository WorkTime,
        ITableMessageRepository TableMessage,
        IRegisteredWorkTimeRepository RegisteredWorkTime,
        IUserDiscountRepository UserDiscount,
        ILastDiscountRepository LastDiscounts
            )
        {
            this.ctx = ctx;
            this.City = City;
            this.Country = Country;
            this.Province = Province;
            this.Document = Document;
            this.ActiveCode = ActiveCode;
            this.Device = Device;
            this.EntityStatus = EntityStatus;
            this.Notification = Notification;
            this.Setting = Setting;
            this.Update = Update;
            this.Roles = Roles;
            this.Users = Users;
            this.UserRoles = UserRoles;
            this.BarginCampaigns = BarginCampaigns;
            this.BarginTypes = BarginTypes;
            this.EventAndLeagues = EventAndLeagues;
            this.GameTypes = GameTypes;
            this.GroupGames = GroupGames;
            this.Products = Products;
            this.ProductImages = ProductImages;
            this.Tables = Tables;
            this.Bills = Bills;
            this.BillItems = BillItems;
            this.Transactions = Transactions;
            this.TransactionCategories = TransactionCategories;
            this.BarginUsers = BarginUsers;
            this.GroupGameUsers = GroupGameUsers;
            this.RegisteredTable = RegisteredTable;
            this.Slider = Slider;
            this.UserTransactionList = UserTransactionList;
            this.TableReserve = TableReserve;
            this.Team = Team;
            this.TeamMember = TeamMember;
            this.EventUsers = EventUsers;
            this.RegisteredTableUserCount = RegisteredTableUserCount;
            this.Message = Message;
            this.BillGames = BillGames;
            this.ProductRate = ProductRate;
            this.WorkTime = WorkTime;
            this.TableMessage = TableMessage;
            this.RegisteredWorkTime = RegisteredWorkTime;
            this.UserDiscount = UserDiscount;
        }
        public IContext ctx { get; set; }
        public ICityRepository City { get; set; }
        public ICountryRepository Country { get; set; }
        public IProvinceRepository Province { get; set; }
        public IDocumentRepository Document { get; set; }
        public IActiveCodeRepository ActiveCode { get; set; }
        public IDeviceRepository Device { get; set; }
        public IEntityStatusRepository EntityStatus { get; set; }
        public INotificationRepository Notification { get; set; }
        public ISettingRepository Setting { get; set; }
        public IUpdateRepository Update { get; set; }
        public IRoleRepository Roles { get; set; }
        public IUserRepository Users { get; set; }
        public IUserRoleRepository UserRoles { get; set; }
        public IBarginCampaignRepository BarginCampaigns { get; set; }
        public IBarginTypeRepository BarginTypes { get; set; }
        public IEventAndLeagueRepository EventAndLeagues { get; set; }
        public IGameTypeRepository GameTypes { get; set; }
        public IGroupGameRepository GroupGames { get; set; }
        public IProductRepository Products { get; set; }
        public IProductImageRepository ProductImages { get; set; }
        public ITableRepository Tables { get; set; }
        public IBillRepository Bills { get; set; }
        public IBillItemRepository BillItems { get; set; }
        public ITransactionRepository Transactions { get; set; }
        public ITransactionCategoryRepository TransactionCategories { get; set; }
        public IRegisteredTableRepository RegisteredTable { get; set; }
        public IGroupGameUsersRepository GroupGameUsers { get; set; }
        public IBarginUsersRepository BarginUsers { get; set; }
        public ISliderRepository Slider{ get; set; }
        public IUserTransactionListRepository UserTransactionList { get; set; }
        public IWorkTimeRepository WorkTime { get; set; }
        public ITableReserveRepository TableReserve { get; set; }
        public ITeamRepository Team { get; set; }
        public ITeamMemberRepository TeamMember { get; set; }
        public IEventUsersRepository EventUsers{ get; set; }
        public IRegisteredTableUserCountRepository RegisteredTableUserCount { get; set; }
        public IMessageRepository Message{ get; set; }
        public IBillGamesRepository BillGames { get; set; }
        public IProductRateRepository ProductRate { get; set; }
        public ITableMessageRepository TableMessage { get; set; }
        public IRegisteredWorkTimeRepository RegisteredWorkTime { get; set; }
        public IUserDiscountRepository UserDiscount { get; set; }
        public ILastDiscountRepository LastDiscounts { get; set; }

        public void Complete()
        {
            ctx.SaveChanges();
        }
    }
}
