namespace MyPosCR.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MyPosCR.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Transaction> Transactions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer("Server=DESKTOP-LTGBELC\\SQLEXPRESS;Database=MyPosCR;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(user =>
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
