using GK.PhoneBook.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PhoneBookDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ICompanyRepository _companyRepository;
        private IPersonRepository _personRepository;

        public UnitOfWork(PhoneBookDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor; 
        }

        public ICompanyRepository CompanyRepository => _companyRepository ??= new CompanyRepository(_context);

        public IPersonRepository PersonRepository => _personRepository ??=  new PersonRepository(_context); 

        public void Dispose()
        {
           _context.Dispose();  
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
           await _context.SaveChangesAsync();   
        }
    }
}
