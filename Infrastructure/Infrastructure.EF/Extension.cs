using Core.ApplicationServices;
using Core.Contracts;
using Core.Entities;
using Core.Entities.GlobalSettings;
using Domain.Contract;
using Infrastructure.EF.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Utility.Tools.Auth;
using Utility.Tools.Notification;
using Utility.Tools.SMS.Rahyab;
using Utility.Tools.Swager;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Infrastructure.EF
{
    public static class Extension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var applicationServiceType = typeof(IApplicationService).Assembly;
            var AllApplicationServices = applicationServiceType.ExportedTypes
               .Where(x => x.IsClass && x.IsPublic && x.FullName.Contains("ApplicationService")).ToList();
            foreach (var type in AllApplicationServices)
            {
                //Console.WriteLine(type.Name);
                services.AddScoped(type.GetInterface($"I{type.Name}"), type);
            }
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            var repositpryType = typeof(Repository<>).Assembly;
            var AllRepositories = repositpryType.ExportedTypes
               .Where(x => x.IsClass && x.IsPublic && x.Name.Contains("Repository") && !x.Name.StartsWith("Repository")).ToList();
            foreach (var type in AllRepositories)
            {
                //Console.WriteLine(type.Name);
                services.AddScoped(type.GetInterface($"I{type.Name}"), type);
            }
        }
        public static void ConfigureServices(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            configuration.GetSection<AdminSettings>();
            services.AddApplicationServices();
            services.AddRepositories();
            services.AddSwager();
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials());
            //});
            //services.AddMvc(options =>
            //{
            //    //options.Filters.Add(typeof(LogFilterAttribute));
            //    options.Filters.Add(typeof(CustomExceptionFilter));
            //    //options.ModelBinderProviders.Insert(0, new CustomBinderProvider());
            //}).AddSessionStateTempDataProvider().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddJwt(configuration);
            configuration.GetSection<RahyabParameters>();
            services.AddScoped<IContext, MainContext>();
            //services.AddDbContext<MainContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Infrastructure.EndPoint")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEncrypter, Encrypter>();
            services.AddScoped<INotification, RahyabService>();

            configuration.GetSection<RahyabParameters>();
            services.AddJwt(configuration);
            services.AddScoped<IContext, MainContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEncrypter, Encrypter>();

            services.AddScoped<INotification, RahyabService>();

        }


        public static void AddEntityConfiguration(this ModelBuilder builder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                         .Where(t => t.GetInterfaces().Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                builder.ApplyConfiguration(configurationInstance);
            }
        }
        public static void SeedData(this ModelBuilder builder)
        {

            builder.Entity<Role>().HasData(new Role { Id = 1, Name = "Mobile" });
            builder.Entity<Role>().HasData(new Role { Id = 2, Name = "Admin" });
            builder.Entity<Role>().HasData(new Role { Id = 3, Name = "Staff" });
            builder.Entity<Role>().HasData(new Role { Id = 4, Name = "Accountant" });


            builder.Entity<Country>().HasData(new Country { Id = 1, Name = "Iran" });
            builder.Entity<Province>().HasData(new Province { Id = 1, Name = "Isfahan", CountryId = 1 });
            builder.Entity<City>().HasData(new City { Id = 1, Name = "Sede", ProvinceId = 1 });
            builder.Entity<City>().HasData(new City { Id = 2, Name = "Shahin Shahr", ProvinceId = 1 });
            builder.Entity<City>().HasData(new City { Id = 3, Name = "Jalal Abad", ProvinceId = 1 });
            builder.Entity<City>().HasData(new City { Id = 4, Name = "Ghahdrijan", ProvinceId = 1 });
            
            
            builder.Entity<EntityStatus>().HasData(new EntityStatus { Id = 0, Name = "Waiting/Deactivated"});
            builder.Entity<EntityStatus>().HasData(new EntityStatus { Id = 1, Name = "Activated/Submited"});
            builder.Entity<EntityStatus>().HasData(new EntityStatus { Id = 2, Name = "Deleted"});
            builder.Entity<EntityStatus>().HasData(new EntityStatus { Id = 3, Name = "Rejected"});
            
            
            builder.Entity<BarginType>().HasData(new BarginType { Id = 1, Name = "درصد"});
            builder.Entity<BarginType>().HasData(new BarginType { Id = 2, Name = "ثابت"});
            
            
            builder.Entity<GameType>().HasData(new GameType { Id = 1, Name = "بازیهای رومیزی"});
            builder.Entity<GameType>().HasData(new GameType { Id = 2, Name = "بازیهای کنسول"});
            
            
            builder.Entity<TransactionCategory>().HasData(new TransactionCategory { Id = 1, Name = "پرداخت"});
            builder.Entity<TransactionCategory>().HasData(new TransactionCategory { Id = 2, Name = "دریافت"});
            builder.Entity<TransactionCategory>().HasData(new TransactionCategory { Id = 3, Name = "ارسال"});
            builder.Entity<TransactionCategory>().HasData(new TransactionCategory { Id = 4, Name = "واریز از درگاه"});
            builder.Entity<TransactionCategory>().HasData(new TransactionCategory { Id = 5, Name = "نقدی"});
            builder.Entity<TransactionCategory>().HasData(new TransactionCategory { Id = 6, Name = "افزایش اعتبار روزانه"});
            builder.Entity<TransactionCategory>().HasData(new TransactionCategory { Id = 7, Name = "کاهش اعتبار روزانه"});
            builder.Entity<TransactionCategory>().HasData(new TransactionCategory { Id = 8, Name = "حقوق"});


            var now = DateTime.Now.ToUnix();
            ///////////////////////////////////////////////
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("6b22b8a8-4402-4127-87f2-7e6df18bf0e6"), Name = "میان وعده",CreatedAt=now,Description = "میان وعده",ParentId = null,Price = 0,StatusId=0 });
            //**********************************************
            //**********************************************
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("18b746d2-7eef-46b6-8ea8-d19de794ed74"), Name = "میان وعده 1", CreatedAt = now, Description = "میان وعده 1", ParentId = Guid.Parse("6b22b8a8-4402-4127-87f2-7e6df18bf0e6"), Price = 0, StatusId = 0 });
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("7e2b0815-956a-432e-b675-21e60f1b1c43"), Name = "میان 1", CreatedAt = now, Description = "", ParentId = Guid.Parse("18b746d2-7eef-46b6-8ea8-d19de794ed74"), Price = 0, StatusId = 0 });
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("3fb5d92d-a5a4-44b8-8a3d-83b7688372c8"), Name = "میان 2", CreatedAt = now, Description = "", ParentId = Guid.Parse("18b746d2-7eef-46b6-8ea8-d19de794ed74"), Price = 0, StatusId = 0 });
            //**********************************************
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("2f036ba7-c577-4870-ade8-c5b71bf5378b"), Name = "میان وعده 2", CreatedAt = now, Description = "میان وعده 2", ParentId = Guid.Parse("6b22b8a8-4402-4127-87f2-7e6df18bf0e6"), Price = 0, StatusId = 0 });
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("73c6db7c-858c-42a1-a004-528fc0d41924"), Name = "میان 3", CreatedAt = now, Description = "", ParentId = Guid.Parse("2f036ba7-c577-4870-ade8-c5b71bf5378b"), Price = 0, StatusId = 0 });
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("b38671d2-aaec-40b3-bd33-37570b2b0eea"), Name = "میان 4", CreatedAt = now, Description = "", ParentId = Guid.Parse("2f036ba7-c577-4870-ade8-c5b71bf5378b"), Price = 0, StatusId = 0 });


            ///////////////////////////////////////////////
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("a2881e4f-43ce-47df-ab15-edb746ef281d"), Name = "نوشیدنی سرد", CreatedAt=now,Description = "نوشیدنی سرد", ParentId = null,Price = 0,StatusId=0 });
            //**********************************************
            //**********************************************
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("57dda9fa-feb2-46e0-b7c3-a619497f1545"), Name = "نوشیدنی سرد 1", CreatedAt = now, Description = "نوشیدنی سرد 1", ParentId = Guid.Parse("a2881e4f-43ce-47df-ab15-edb746ef281d"), Price = 0, StatusId = 0 });
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("e1fa6eb1-2c9b-4c19-99bd-07655f1eaf04"), Name = "نوش 1", CreatedAt = now, Description = "", ParentId = Guid.Parse("57dda9fa-feb2-46e0-b7c3-a619497f1545"), Price = 0, StatusId = 0 });
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("cd9b33b5-881e-4d01-8cb2-67e75436ce36"), Name = "نوش 2", CreatedAt = now, Description = "", ParentId = Guid.Parse("57dda9fa-feb2-46e0-b7c3-a619497f1545"), Price = 0, StatusId = 0 });
            //**********************************************
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("b3215f0c-eb04-4371-b11b-6d554bd7deaa"), Name = "نوشیدنی سرد 2", CreatedAt = now, Description = "نوشیدنی سرد 2", ParentId = Guid.Parse("a2881e4f-43ce-47df-ab15-edb746ef281d"), Price = 0, StatusId = 0 });
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("49f637fb-7434-4429-9a3d-0b061dfd9aee"), Name = "نوش 3", CreatedAt = now, Description = "", ParentId = Guid.Parse("b3215f0c-eb04-4371-b11b-6d554bd7deaa"), Price = 0, StatusId = 0 });
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("1f19acd9-54df-4898-9a73-322bb21f0827"), Name = "نوش 4", CreatedAt = now, Description = "", ParentId = Guid.Parse("b3215f0c-eb04-4371-b11b-6d554bd7deaa"), Price = 0, StatusId = 0 });

            ///////////////////////////////////////////////
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("d340e0f7-7ebd-4b3f-bc4c-115e224546d1"), Name = "سردنوش گیاهی", CreatedAt=now,Description = "سردنوش گیاهی", ParentId = null,Price = 0,StatusId=0 });
            //**********************************************
            //**********************************************
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("daf5bb7e-5d45-403f-a120-230bb35928eb"), Name = "سردنوش گیاهی 1", CreatedAt = now, Description = "سردنوش گیاهی 1", ParentId = Guid.Parse("d340e0f7-7ebd-4b3f-bc4c-115e224546d1"), Price = 0, StatusId = 0 });
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("f36da1d0-11f6-4b0a-9bdd-292c4eb056e2"), Name = "سردنوش 1", CreatedAt = now, Description = "", ParentId = Guid.Parse("daf5bb7e-5d45-403f-a120-230bb35928eb"), Price = 0, StatusId = 0 });
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("bf856381-349c-41b6-ad9c-e54a2f054447"), Name = "سردنوش 2", CreatedAt = now, Description = "", ParentId = Guid.Parse("daf5bb7e-5d45-403f-a120-230bb35928eb"), Price = 0, StatusId = 0 });
            //**********************************************
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("c056d1cb-d42e-4c66-b430-cbfd4775a842"), Name = "سردنوش گیاهی 2", CreatedAt = now, Description = "سردنوش گیاهی 2", ParentId = Guid.Parse("d340e0f7-7ebd-4b3f-bc4c-115e224546d1"), Price = 0, StatusId = 0 });
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("cfeed39b-c410-4767-927c-1be02c8c9096"), Name = "سردنوش 3", CreatedAt = now, Description = "", ParentId = Guid.Parse("c056d1cb-d42e-4c66-b430-cbfd4775a842"), Price = 0, StatusId = 0 });
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("211d7f77-c324-417e-9e73-ba5bcc6c42ff"), Name = "سردوش 4", CreatedAt = now, Description = "", ParentId = Guid.Parse("c056d1cb-d42e-4c66-b430-cbfd4775a842"), Price = 0, StatusId = 0 });
            ///////////////////////////////////////////////
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("69eb1978-7fc3-4936-b43b-ca1d3d1d90ad"), Name = "نوشیدنی گرم", CreatedAt=now,Description = "نوشیدنی گرم", ParentId = null,Price = 0,StatusId=0 });
            //**********************************************
            //**********************************************
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("86e88e9c-3e6c-4bf1-9f27-86fe1550f7cc"), Name = "قهوه ها", CreatedAt = now, Description = "قهوه ها", ParentId = Guid.Parse("69eb1978-7fc3-4936-b43b-ca1d3d1d90ad"), Price = 0, StatusId = 0 });
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("c5ac0554-3e81-4655-97a2-35415a96afe1"), Name = "قهوه 1", CreatedAt = now, Description = "", ParentId = Guid.Parse("86e88e9c-3e6c-4bf1-9f27-86fe1550f7cc"), Price = 0, StatusId = 0 });
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("042d0c7c-028d-4a54-be9b-1b019c7b7e27"), Name = "قهوه 2", CreatedAt = now, Description = "", ParentId = Guid.Parse("86e88e9c-3e6c-4bf1-9f27-86fe1550f7cc"), Price = 0, StatusId = 0 });
            //**********************************************
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("b29d2e3f-839f-4666-8da6-fb15dc3e955c"), Name = "کاپوچینوها", CreatedAt = now, Description = "کاپوچینوها", ParentId = Guid.Parse("69eb1978-7fc3-4936-b43b-ca1d3d1d90ad"), Price = 0, StatusId = 0 });
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("cb76002a-43d6-4516-bcb1-d2782ad7c6c0"), Name = "کاپوچینو 1", CreatedAt = now, Description = "", ParentId = Guid.Parse("b29d2e3f-839f-4666-8da6-fb15dc3e955c"), Price = 0, StatusId = 0 });
            builder.Entity<Product>().HasData(new Product { Id = Guid.Parse("6bff0dca-8871-44ba-b0ce-fd892c70dce1"), Name = "کاپوچینو 2", CreatedAt = now, Description = "", ParentId = Guid.Parse("b29d2e3f-839f-4666-8da6-fb15dc3e955c"), Price = 0, StatusId = 0 });



            User user = new User
            {
                Mobile = "09130097415",
                Name = "مدیر",
                FamilyName = "کل",
                Id = Guid.Parse("8114eb2e-3588-4239-98a4-f7e3023674e8"),
                Status = Enums.EntityStatus.Active.ToInt(),
            };
            user.SetPassword("123456", new Encrypter());
            builder.Entity<User>().HasData(user);
            builder.Entity<UserRole>().HasData(new UserRole { CreatedAt = DateTime.Now.ToUnix(), Id = Guid.Parse("44fc4a46-6bd7-45d0-a911-b989ed4a944c"), RoleId = 2, UserId = Guid.Parse("8114eb2e-3588-4239-98a4-f7e3023674e8")});
            
            
            
            builder.Entity<Setting>().HasData(new Setting{Id = 1, Name = "MaxStaffBying",Description = "سقف خرید پرسنل",Value = "50000"});
            builder.Entity<Setting>().HasData(new Setting{Id = 2, Name = "TeamPrice",Description = "هزینه ساخت تیم",Value = "50000"});
            builder.Entity<Setting>().HasData(new Setting{Id = 3, Name = "DaysForLoyalty", Description = "مبلغ خرید در این تعداد روز برای تعلق جایزه",Value = "30"});
            builder.Entity<Setting>().HasData(new Setting{Id = 4, Name = "BuyingForLoyalty", Description = "میزان خرید برای جایزه",Value = "100000"});
            builder.Entity<Setting>().HasData(new Setting{Id = 5, Name = "RewardForLoyalty", Description = "جایزه برای خرید بیش از یک مقداری",Value = "5000"});

           

            //using (var str = new StreamReader(@"Province.json"))
            //{
            //    var resul = Api.ToObject<List<ProvinceAndCitys>>(str.ReadToEnd());

            //    int provienceCounter = 1, cityCounter = 1;


            //    resul.ForEach(p =>
            //    {
            //        List<City> cities = new List<City>();
            //        p.cities.ForEach(q =>
            //        {
            //            cities.Add(new Core.Entities.City { Name = q.name, ProvinceId = provienceCounter, Id = cityCounter++ });
            //        });
            //        builder.Entity<Province>().HasData(new Core.Entities.Province { Id = provienceCounter++, Name = p.name });
            //        builder.Entity<City>().HasData(cities.ToArray());
            //    });
            //}



        }
    }
}
