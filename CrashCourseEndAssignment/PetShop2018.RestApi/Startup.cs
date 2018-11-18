using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PetShop2018.Core.ApplicationService;
using PetShop2018.Core.ApplicationService.Services;
using PetShop2018.Core.DomainService;
using PetShop2018.Infrastructure.Data;
using PetShop2018.Infrastructure.Data.SQLRepositories;

namespace PetShop2018.RestApi
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
            //Old DB
            //services.AddDbContext<PetShop2018Context>( opt => opt.UseInMemoryDatabase("DBOne"));

            services.AddDbContext<PetShop2018Context>( 
                opt => opt.UseSqlite("Data Source=petShop2018.db"));

            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();

            services.AddScoped<IPreviousOwnerRepository, PreviousOwnerRepository>();
            services.AddScoped<IPreviousOwnerService, PreviousOwnerService>();

            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShop2018Context>();
                    DBInitializer.SeedDB(ctx);
                }
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc();
        }
    }
}
