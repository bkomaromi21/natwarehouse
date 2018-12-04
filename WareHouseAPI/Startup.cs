using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WareHouseAPI.Database;

namespace WareHouseAPI
{
    public class Startup
    {
        // Adding services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = "Server=localhost;Database=WarehouseDB;User Id=sa;Password=SecretPass0!";
            services.AddDbContext<WarehouseDbContext>(o => o.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, WarehouseDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            dbContext.CreateSeedData();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
