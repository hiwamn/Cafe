using Domain.Contract;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Core.Contracts;
using Utility.Tools.Auth;
using Infrastructure.EF;
using Utility.Tools.Notification;
using Core.ApplicationServices;
using Utility.Tools.SMS.Rahyab;
using Infrastructure.EndPoint.Controllers;
using Core.Entities.Dto;
using Utility.Tools.General;
using Utility.Tools;

namespace ConsoleCore
{
    class Program
    {
        public static Task[] TaskList = new Task[500];
        public static List<string> list = new List<string>();


        public static IUnitOfWork Iunit { get; private set; }
        public static INotification Notification { get; private set; }
        public static IEncrypter Encrypter { get; private set; }
        public static IJwtHandler JwtHandler { get; private set; }
        public static IFireBase Firebase { get; private set; }
        public static IConfiguration Configuration { get; set; }



        static async Task Main()
        {
            Config();

            var getBillsByPage = new GetBillsByPage(Iunit);
            getBillsByPage.Execute(new BaseByUserPageBillDto { From = 0, Type = 0 });

            var getOrdersByPage = new GetOrdersByPage(Iunit);
            getOrdersByPage.Execute(new GetOrdersByPageDto { From = 0, Type = 0 });

            //AddGameToTable addGameToTable = new AddGameToTable(Iunit, new GetTables(Iunit), new CalculatePrice(Iunit), new SendAccountantNotification(Iunit));
            //addGameToTable.Execute(new AddGameToTableDto
            //{
            //    Count = 2,
            //    Type = 3,
            //    GameTypeId = 1,
            //    UserId =  Guid.Parse("20df04f0-ffdb-41ec-5543-08d80b8c0b30"),
            //    TableId = Guid.Parse("1796db7a-e053-4cd6-8fb5-84e327e31449")
            //});


            //SendNotification sendNotification = new SendNotification(Iunit, Firebase);
            //sendNotification.Execute(new SendNotificationDto { UserId = Guid.Parse("20DF04F0-FFDB-41EC-5543-08D80B8C0B30"),Text = "salam",Title = "salam" });
            //ReserveATable res = new ReserveATable(Iunit,new GetUserById(Iunit,JwtHandler));
            //res.Execute(new ReserveATableDto {UserId = Guid.Parse("20df04f0-ffdb-41ec-5543-08d80b8c0b30"),BarCode = "Table-2" });

            GetTables getTables = new GetTables(Iunit);
            getTables.Execute();
            Console.ReadKey();

        }



        public static void Config()
        {
            ServiceCollection service = new ServiceCollection();
            var builder = new ConfigurationBuilder().SetBasePath(@"C:\Projects\Zigorat\Cafe\Infrastructure\Infrastructure.EndPoint\").AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddEnvironmentVariables();
            Configuration = builder.Build();

            service.AddSingleton<IConfiguration>(builder.Build());


            service.ConfigureServices(Configuration);
            service.AddDbContext<MainContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            service.AddScoped<IFireBase, FireBase>();

            //Configuration.GetSection<MobileData>("MobileData");
            //Configuration.GetSection<PaymentData>("PaymentData");

            var provider = service.BuildServiceProvider();
            Iunit = provider.GetService<IUnitOfWork>();
            Encrypter = provider.GetService<IEncrypter>();
            Notification = provider.GetService<INotification>();
            JwtHandler = provider.GetService<IJwtHandler>();
            Firebase = provider.GetService<IFireBase>();
        }


        private static void ReadKey()
        {
            var key = Console.ReadKey();
            if (key.KeyChar != 13)
                ReadKey();
            Console.Write(key.KeyChar);
        }


    }






}
