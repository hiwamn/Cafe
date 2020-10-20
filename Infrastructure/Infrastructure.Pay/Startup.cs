using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Contracts;
using Core.Entities.GlobalSettings;
using Domain.Contract;
using Infrastructure.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Utility.Tools.Exceptions;
using Utility.Tools.Swager;

namespace Infrastructure.Pay
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServices();
            services.AddRepositories();
            Configuration.GetSection<PaymentData>();
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
            services.AddDbContext<MainContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Infrastructure.EndPoint")));
            services.AddScoped<IContext, MainContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            //app.ConfigureSwager();
            app.UseMvcWithDefaultRoute();
        }
    }
}
