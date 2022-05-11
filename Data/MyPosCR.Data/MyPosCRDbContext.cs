using Microsoft.EntityFrameworkCore;
using MyPosCR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPosCR.Data
{
    internal class MyPosCRDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer("Server=DESKTOP-LTGBELC\\SQLEXPRESS;Database=MyPosCR;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<User>(user =>
            {
                user
                    .HasMany(s => s.SendedTransactions)
                    .WithOne(s => s.Sender)
                    .HasForeignKey(s => s.SenderId)
                    .OnDelete(DeleteBehavior.Restrict);

                user
                    .HasMany(s => s.RecievedTransactions)
                    .WithOne(s => s.Reciever)
                    .HasForeignKey(s => s.RecieverId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
