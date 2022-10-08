﻿using Microsoft.EntityFrameworkCore.Query;
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
        Task<T> Get(int id);
        Task<IQueryable<T>> Get();
        Task<IReadOnlyList<T>> GetAll();
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate,Func<IQueryable<T>, IIncludableQueryable<T,object>> include);
        Task<T> Add(T entity);
        Task<bool> Exists(int id);
        Task Update(T entity);
        Task Delete(T entity);
        
        

    }
}
