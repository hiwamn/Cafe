
using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EF
{
    public interface IContext 
    {
        DbSet<City> Cities { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Province> Provinces { get; set; }
        DbSet<Document> Documents { get; set; }
        DbSet<ActiveCode> ActiveCodes { get; set; }
        DbSet<Device> Devices { get; set; }
        DbSet<EntityStatus> EntityStatuses { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<Setting> Settings { get; set; }
        DbSet<Update> Updates { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserRole> UserRoles { get; set; }

        DbSet<BarginCampaign> BarginCampaigns { get; set; }
        DbSet<BarginType> BarginTypes { get; set; }
        DbSet<EventAndLeague> EventAndLeagues { get; set; }
        DbSet<GameType> GameTypes { get; set; }
        DbSet<GroupGame> GroupGames { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<Table> Tables { get; set; }
        DbSet<Bill> Bills { get; set; }
        DbSet<BillItem> BillItems { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<TransactionCategory> TransactionCategories { get; set; }
        DbSet<BarginUsers> BarginUsers { get; set; }
        DbSet<GroupGameUsers> GroupGameUsers { get; set; }
        DbSet<RegisteredTable> RegisteredTable { get; set; }
        DbSet<Slider> Slider { get; set; }
        DbSet<UserTransactionList> UserTransactionList { get; set; }
        DbSet<WorkTime> WorkTime { get; set; }
        DbSet<TableReserve> TableReserve { get; set; }
        DbSet<Team> Team { get; set; }
        DbSet<TeamMember> TeamMember { get; set; }
        DbSet<EventUsers> EventUsers { get; set; }
        DbSet<RegisteredTableUserCount> RegisteredTableUserCount { get; set; }
        DbSet<Message> Message { get; set; }
        DbSet<BillGames> BillGames { get; set; }
        DbSet<ProductRate> ProductRate { get; set; }
        DbSet<TableMessage> TableMessage { get; set; }
        DbSet<RegisteredWorkTime> RegisteredWorkTime { get; set; }
        DbSet<UserDiscount> UserDiscount { get; set; }
        DbSet<BarginUserBills> BarginUserBills { get; set; }
        DbSet<LastDiscount> LastDiscounts { get; set; }
       
        void SaveChanges();
        

    }
}