using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface IUnitOfWork
    {
        ICityRepository City { get; set; }
        ICountryRepository Country { get; set; }
        IProvinceRepository Province { get; set; }
        IDocumentRepository Document { get; set; }
        IActiveCodeRepository ActiveCode { get; set; }
        IDeviceRepository Device { get; set; }
        IEntityStatusRepository EntityStatus { get; set; }
        INotificationRepository Notification { get; set; }
        ISettingRepository Setting { get; set; }
        IUpdateRepository Update { get; set; }
        IRoleRepository Roles { get; set; }
        IUserRepository Users { get; set; }
        IUserRoleRepository UserRoles { get; set; }
        IBarginCampaignRepository BarginCampaigns { get; set; }
        IBarginTypeRepository BarginTypes { get; set; }
        IEventAndLeagueRepository EventAndLeagues { get; set; }
        IGameTypeRepository GameTypes { get; set; }
        IGroupGameRepository GroupGames { get; set; }
        IProductRepository Products { get; set; }
        IProductImageRepository ProductImages { get; set; }
        ITableRepository Tables { get; set; }
        IBillRepository Bills { get; set; }
        IBillItemRepository BillItems { get; set; }
        ITransactionRepository Transactions { get; set; }
        ITransactionCategoryRepository TransactionCategories { get; set; }
        IRegisteredTableRepository RegisteredTable{ get; set; }
        IGroupGameUsersRepository GroupGameUsers{ get; set; }
        IBarginUsersRepository BarginUsers{ get; set; }
        ISliderRepository Slider{ get; set; }
        IUserTransactionListRepository UserTransactionList{ get; set; }
        IWorkTimeRepository WorkTime{ get; set; }
        ITableReserveRepository TableReserve { get; set; }
        ITeamRepository Team{ get; set; }
        ITeamMemberRepository TeamMember{ get; set; }
        IEventUsersRepository EventUsers{ get; set; }
        IRegisteredTableUserCountRepository RegisteredTableUserCount { get; set; }
        IMessageRepository Message { get; set; }
        IBillGamesRepository BillGames{ get; set; }
        IProductRateRepository ProductRate{ get; set; }
        ITableMessageRepository TableMessage { get; set; }
        IRegisteredWorkTimeRepository RegisteredWorkTime { get; set; }
        IUserDiscountRepository UserDiscount { get; set; }
        ILastDiscountRepository LastDiscounts { get; set; }


        void Complete();
    }
}
