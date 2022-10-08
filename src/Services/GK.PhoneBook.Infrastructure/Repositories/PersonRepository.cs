using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Infrastructure.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private readonly PhoneBookDbContext _dbContext;
        public PersonRepository(PhoneBookDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
