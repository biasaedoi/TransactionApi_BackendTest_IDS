using Microsoft.EntityFrameworkCore;
using TransactionApi.Models;

namespace TransactionApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().ToTable("transactions");
            modelBuilder.Entity<Status>().ToTable("status");
        }
    }
}
