using GK.PhoneBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Infrastructure.DbSeeds
{
    public static class PhoneBookDbSeedData
    {
        public static void EnsureSeed(ModelBuilder modelBuilder)
        {
            CompanySeed(modelBuilder);
            PersonSeed(modelBuilder);
          
        }

        private static void CompanySeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
            new Company
            {
                Id = 1,
                Name = "Blue Company",
                EmployeeCount = 50,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
             new Company
             {
                 Id = 2,
                 Name = "Green Company",
                 EmployeeCount = 30,
                 CreatedDate = DateTime.Now,
                 UpdatedDate = DateTime.Now
             },
              new Company
              {
                  Id = 3,
                  Name = "Red Company",
                  EmployeeCount = 10,
                  CreatedDate = DateTime.Now,
                  UpdatedDate = DateTime.Now
              });
        }

        private static void PersonSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
            new Person
            {
                Id = 1,
                FullName = "Gizem Kgizem",
                Address ="Izmir/Turkey",
                PhoneNumber ="+905073452312",
                CompanyId =1,
                CreatedDate =DateTime.Now,
                UpdatedDate = DateTime.Now
            },
             new Person
             {
                 Id = 2,
                 FullName = "Rose KRose",
                 Address = "Ankara/Turkey",
                 PhoneNumber = "+905073455512",
                 CompanyId = 2,
                 CreatedDate = DateTime.Now,
                 UpdatedDate = DateTime.Now
             },
            new Person
            {
                Id = 3,
                FullName = "Melinda GMelindaGates",
                Address = "Istanbul/Turkey",
                PhoneNumber = "+905073455512",
                CompanyId = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });
        }
    }
}
