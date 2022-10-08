using GK.PhoneBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GK.PhoneBook.Infrastructure
{
    public class PhoneBookDbContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "pb";

        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().ToTable("Companies", DEFAULT_SCHEMA);
            modelBuilder.Entity<Person>().ToTable("OrderItems", DEFAULT_SCHEMA);
            base.OnModelCreating(modelBuilder);
        }
    }
}