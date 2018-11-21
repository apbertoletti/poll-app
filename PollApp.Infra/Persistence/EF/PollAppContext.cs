using Microsoft.EntityFrameworkCore;
using PollApp.Domain.Entities;
using PollApp.Infra.Persistence.EF.Maps;
using PollApp.Shared;

namespace PollApp.Infra.Persistence.EF
{
    public class PollAppContext : DbContext
    {
        public DbSet<Poll> Polls { get; set; }

        public DbSet<PollOption> PollOptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PollMap());
            modelBuilder.ApplyConfiguration(new PollOptionMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
