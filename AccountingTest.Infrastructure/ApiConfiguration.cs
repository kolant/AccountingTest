using System;
using System.Collections.Generic;
using System.Text;
using AccountingTest.Infrastructure.Abstractions;
using AccountingTest.Infrastructure.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccountingTest.Infrastructure
{
    public class ApiConfiguration
    {
        private IConfiguration Configuration { get; set; }

        public ApiConfiguration(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureCommonServices(IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }
}
