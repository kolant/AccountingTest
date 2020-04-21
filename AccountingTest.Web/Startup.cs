using System;
using AccountingTest.Domain.Models;
using AccountingTest.Infrastructure;
using AccountingTest.Service.Account;
using AccountingTest.Service.Transactions;
using AccountingTest.Web.Extentions;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccountingTest
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
            var apiConfiguration = new ApiConfiguration(this.Configuration);
            apiConfiguration.ConfigureCommonServices(services);

            services.AddAutoMapper();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITransactionService, TransactionService>();

            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("AppDb"));

            services.AddMemoryCache();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.ConfigureCustomExceptionMiddleware();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });


            SeedData(app);
        }

        private static void SeedData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                var testUserAccount = new Account
                {
                    Id = Guid.NewGuid().ToString(),
                    BalanceValue = 0
                };

                var testUser = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Luke",
                    LastName = "Skywalker",
                    AccountId = testUserAccount.Id
                };

                context.Accounts.Add(testUserAccount);
                context.Users.Add(testUser);

                context.SaveChanges();
            }
        }
    }
}
