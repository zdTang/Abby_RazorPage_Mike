using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace Abby.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AbbyDbContext? _dbContext;
        internal DbSet<T> dbSet;  //Internal types or members are accessible only within files in the same assembly

        public Repository(AbbyDbContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<T>();   // Get this T type Entity from dbContext
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null,
            string? includeProperties = null)
        {
            //========================version one - tutor
            //IQueryable<T> query = dbSet;
            //return query.ToList();
            //=========================version two - Mike
            //return dbSet.AsQueryable<T>().ToList();
            //=========================version 3 --add 'include" - tutor
            //IQueryable<T> query = dbSet;
            //if (includeProperties != null)
            //{
            //    //abc,,xyz -> abc xyz
            //    foreach (var includeProperty in includeProperties.Split(
            //        new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            //    {
            //        query = query.Include(includeProperty);
            //    }
            //}

            /* Here we put those parameters into action*/

            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                //abc,,xyz -> abc xyz
                foreach (var includeProperty in includeProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderby != null)
            {
                return orderby(query).ToList();
            }
            return query.ToList();

        }
        // At first, we use Find(), which can only work based on Id, the function is limited.
        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            //IQueryable<T> query = dbSet;
            //if (filter != null)
            //{
            //    query = query.Where(filter);
            //}
            //return query.FirstOrDefault();


            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                //abc,,xyz -> abc xyz
                foreach (var includeProperty in includeProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault();


        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
