using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

            services.AddMvc();
        }

        // Configuring the request pipeline and creating initial data for the database
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, WarehouseDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            dbContext.CreateSeedData();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
