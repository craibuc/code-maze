using Microsoft.EntityFrameworkCore;

using Domain.Models;
using Domain.Configuration;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
        }
    }
}
