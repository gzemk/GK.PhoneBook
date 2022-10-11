using GK.PhoneBook.Domain.Entities;
using GK.PhoneBook.Infrastructure.DbSeeds;
using Microsoft.EntityFrameworkCore;

namespace GK.PhoneBook.Infrastructure
{
    public class PhoneBookDbContext : AuditableDbContext
    {
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PhoneBookDbContext).Assembly);
            PhoneBookDbSeedData.EnsureSeed(modelBuilder);
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}