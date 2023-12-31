﻿using System.Linq.Expressions;

namespace Abby.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //GET ALL, GET By ID FIRST OR DEFAULT, ADD, REMOVE, REMOVERANGE
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        //IEnumerable<T> GetAll(string? includeProperties = null);
        // This use lambda expression, can get anything based on given logic
        //T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null,
            string? includeProperties = null); // before, we only have Include parameters

        T GetFirstOrDefault(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null);
    }
}
