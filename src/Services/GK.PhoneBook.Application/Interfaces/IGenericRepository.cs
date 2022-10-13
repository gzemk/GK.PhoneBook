using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        IQueryable<T> Get();
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> predicate);
        List<T> GetAll(Expression<Func<T, bool>> predicate,Func<IQueryable<T>, IIncludableQueryable<T,object>> include);
        Task<T> Add(T entity);
        Task<bool> Exists(int id);
        T Update(T entity);
        Task Delete(T entity);
    }
}
