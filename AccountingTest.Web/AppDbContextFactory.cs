using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AccountingTest.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace AccountingTest.Web
{
    public class AppbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();

            builder.UseInMemoryDatabase("AppDb");

            return new AppDbContext(builder.Options);
        }
    }
}
