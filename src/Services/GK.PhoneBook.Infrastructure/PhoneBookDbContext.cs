using GK.PhoneBook.Domain.Entities;
using GK.PhoneBook.Infrastructure.DbSeeds;
using Microsoft.EntityFrameworkCore;

namespace GK.PhoneBook.Infrastructure
{
    public class PhoneBookDbContext : AuditableDbContext
    {
        public const string DEFAULT_SCHEMA = "pb";

        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PhoneBookDbContext).Assembly);
            modelBuilder.Entity<Company>().ToTable("Companies", DEFAULT_SCHEMA);
            modelBuilder.Entity<Person>().ToTable("Persons", DEFAULT_SCHEMA);
            base.OnModelCreating(modelBuilder);

            PhoneBookDbSeedData.EnsureSeed(modelBuilder);
        }
    }
}