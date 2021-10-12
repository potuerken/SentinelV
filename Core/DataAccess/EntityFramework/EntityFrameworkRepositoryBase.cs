using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EntityFrameworkRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class/*, IEntity*/, new()
    where TContext : DbContext, new()
    {
        #region OldCode
        //public int Add(TEntity entity)
        //{
        //    //IDisposable pattern implementation of c#
        //    using (TContext context = new TContext())
        //    {
        //        var addedEntity = context.Entry(entity);
        //        addedEntity.State = EntityState.Added;
        //        return context.SaveChanges();
        //    }
        //}

        //public int Delete(TEntity entity)
        //{
        //    using (TContext context = new TContext())
        //    {
        //        var deletedEntity = context.Entry(entity);
        //        deletedEntity.State = EntityState.Deleted;
        //        return context.SaveChanges();
        //    }
        //}

        //public TEntity Get(Expression<Func<TEntity, bool>> filter)
        //{
        //    using (TContext context = new TContext())
        //    {
        //        return context.Set<TEntity>().SingleOrDefault(filter);
        //    }
        //}

        //public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        //{
        //    using (TContext context = new TContext())
        //    {
        //        return filter == null
        //            ? context.Set<TEntity>().ToList()
        //            : context.Set<TEntity>().Where(filter).ToList();
        //        //var result = context.Set<TEntity>().Where(filter).AsQueryable();

        //        //var relations = includedProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //        //foreach (var property in relations)
        //        //{
        //        //    result = result.Include(property);
        //        //}

        //        //return result.ToList();
        //    }
        //}

        //public int Update(TEntity entity)
        //{
        //    using (TContext context = new TContext())
        //    {
        //        var updatedEntity = context.Entry(entity);
        //        updatedEntity.State = EntityState.Modified;
        //        return context.SaveChanges();
        //    }
        //}
        #endregion

        #region NtierCode
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var db = new TContext())
            {
                var result = db.Set<TEntity>().FirstOrDefault(filter);
                return result;
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, string includeProperties)
        {
            using (var db = new TContext())
            {
                var result = db.Set<TEntity>().Where(filter).AsQueryable();

                var relations = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var property in relations)
                {
                    result = result.Include(property);
                }
                return result.FirstOrDefault();
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var db = new TContext())
            {
                var result = filter == null
                    ? db.Set<TEntity>().ToList()
                    : db.Set<TEntity>().Where(filter).ToList();
                return result;
            }
        }

        public IQueryable<TEntity> Include(string[] includes)
        {
            using (var db = new TContext())
            {
                var result = db.Set<TEntity>().AsQueryable();
                if (includes.Length > 0)
                {
                    foreach (var item in includes)
                    {
                        result.Include(item);
                    }
                }
                return result;
            }
        }

        //public static IQueryable<T> IncludeMultiple<T>(IQueryable<T> query, params Expression<Func<T, object>>[] includes)
        //{
        //    if (includes != null)
        //    {
        //        query = includes.Aggregate(query,
        //                  (current, include) => current.Include(include));
        //    }

        //    return query;
        //}

        //public IEnumerable<TEntity> Include(params Expression<Func<TEntity, object>>[] includes)
        //{
        //    using (var db = new TContext())
        //    {
        //        var dbSet = db.Set<TEntity>();

        //        IEnumerable<TEntity> query = null;
        //        foreach (var include in includes)
        //        {
        //            query = dbSet.Include(include);
        //        }

        //        return query ?? dbSet;
        //    }
        //}

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter, string includedProperties)
        {
            using (var db = new TContext())
            {
                var result = db.Set<TEntity>().Where(filter).AsQueryable();

                var relations = includedProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var property in relations)
                {
                    result = result.Include(property);
                }
                return result.ToList();
            }
        }

        public int Add(TEntity entity)
        {
            using (var db = new TContext())
            {
                entity.GetType().GetProperty("IlkKayitTarihi").SetValue(entity, DateTime.Now);
                db.Entry(entity).State = EntityState.Added;
                
                return db.SaveChanges();
            }
        }

        public int Update(TEntity entity)
        {
            using (var db = new TContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }


        #endregion
    }
}
