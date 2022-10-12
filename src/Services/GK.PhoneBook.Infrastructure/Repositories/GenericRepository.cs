using GK.PhoneBook.Application.Interfaces;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace GK.PhoneBook.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PhoneBookDbContext _dbContext;

        public GenericRepository(PhoneBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetById(id);
            return entity != null;
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual IQueryable<T> Get()
        {
            return GetQueryable();
        }

        public List<T> GetAll()
        {
            return GetQueryable(null, null).ToList();
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return GetQueryable(predicate, null).ToList();
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include)
        {
            return GetQueryable(predicate, include).ToList();
        }

        public virtual T Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return entity;
        }

        private IQueryable<T> GetQueryable(Expression<Func<T,bool>> predicate  = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (include != null)
            {
                query = include(query);
            }
            predicate ??= PredicateBuilder.New<T>(true);
            query = query.Where(predicate);
            Console.WriteLine(query.ToQueryString());
            return query.AsNoTracking();
        }
    }
}
