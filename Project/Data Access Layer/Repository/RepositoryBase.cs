using Data_Access_Layer.Context;
using Data_Access_Layer.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data_Access_Layer.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected TestingDB context { get; set; }
        public RepositoryBase(TestingDB testingDB)
        {
            context = testingDB;
        }
        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public IQueryable<T> FindAll()
        {
            return context.Set<T>()
                .AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>()
                .Where(predicate)
                .AsNoTracking();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
    }
}