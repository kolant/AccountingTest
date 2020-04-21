using System;
using System.Collections.Generic;
using System.Text;
using AccountingTest.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountingTest.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            SetupTables(builder);
        }

        private static void SetupTables(ModelBuilder modelBuilder)
        {
            // Users
            modelBuilder.Entity<User>()
                .HasOne(x => x.Account)
                .WithOne(x => x.User)
                .HasForeignKey<Account>(a => a.UserId);

            // Account
            modelBuilder.Entity<Account>()
                .HasOne(x => x.User)
                .WithOne(x => x.Account)
                .HasForeignKey<User>(a => a.AccountId);

            modelBuilder.Entity<Account>()
                .HasMany(x => x.Transactions)
                .WithOne(x => x.Account);

            // Transaction
            modelBuilder.Entity<Transaction>()
                .HasOne(x => x.Account)
                .WithMany(x => x.Transactions);

        }
    }
}
