using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Core.ApplicationServices;
using Core.Contracts;
using Core.Entities.GlobalSettings;
using Domain.Contract;
using Infrastructure.EF;
using Infrastructure.EF.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Utility.Tools;
using Utility.Tools.Auth;
using Utility.Tools.Exceptions;
using Utility.Tools.Notification;
using Utility.Tools.SMS.Rahyab;
using Utility.Tools.Swager;

namespace Infrastructure.EndPoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.GetSection<AdminSettings>();            
            services.AddApplicationServices();
            services.AddRepositories();
            services.AddSwager();
            services
             .AddCors(options =>
             {
                 options.AddPolicy("CorsPolicy",
                     builder => builder
                     .AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     );

                 options.AddPolicy("signalr",
                     builder => builder
                     .AllowAnyMethod()
                     .AllowAnyHeader()

                     .AllowCredentials()
                     .SetIsOriginAllowed(hostName => true));
             });
            services.AddMvc(options =>
            {
                //options.Filters.Add(typeof(LogFilterAttribute));
                options.Filters.Add(typeof(CustomExceptionFilter));
                //options.ModelBinderProviders.Insert(0, new CustomBinderProvider());
                options.EnableEndpointRouting = false;
            }).AddSessionStateTempDataProvider().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddJwt(Configuration);
            services.AddScoped<IEncrypter, Encrypter>();
            services.AddScoped<INotification, RahyabService>();
            services.AddDbContext<MainContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Infrastructure.EndPoint")));
            services.AddScoped<IContext, MainContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFireBase, FireBase>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureSwager();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseMvcWithDefaultRoute();
        }
    }
}
