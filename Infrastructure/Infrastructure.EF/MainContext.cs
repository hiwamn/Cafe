using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Reflection;

namespace Infrastructure.EF
{
    public class MainContext : DbContext, IContext
    {
        public DbSet<BarginCampaign> BarginCampaigns { get; set; }
        public DbSet<BarginType> BarginTypes { get; set; }
        public DbSet<EventAndLeague> EventAndLeagues { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<GroupGame> GroupGames { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionCategory> TransactionCategories{ get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<ActiveCode> ActiveCodes { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<EntityStatus> EntityStatuses { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Update> Updates { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<BarginUsers> BarginUsers { get; set; }
        public DbSet<GroupGameUsers> GroupGameUsers { get; set; }
        public DbSet<RegisteredTable> RegisteredTable { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<UserTransactionList> UserTransactionList { get; set; }
        public DbSet<WorkTime> WorkTime { get; set; }
        public DbSet<TableReserve> TableReserve { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TeamMember> TeamMember { get; set; }
        public DbSet<EventUsers> EventUsers { get; set; }
        public DbSet<RegisteredTableUserCount> RegisteredTableUserCount { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<BillGames> BillGames { get; set; }
        public DbSet<ProductRate> ProductRate { get; set; }
        public DbSet<TableMessage> TableMessage { get; set; }
        public DbSet<RegisteredWorkTime> RegisteredWorkTime { get; set; }
        public DbSet<UserDiscount> UserDiscount { get; set; }
        public DbSet<BarginUserBills> BarginUserBills { get; set; }
        public DbSet<LastDiscount> LastDiscounts { get; set; }
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {

        }

        public MainContext()
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Infrastructure.EF")/*, sqlServerOptions => sqlServerOptions.CommandTimeout(600)*/);
            //this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.AddEntityConfiguration();
            builder.SeedData();
        }

        void IContext.SaveChanges()
        {
            this.SaveChanges();
        }
    }
}
