using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    //generic constraint
    //class : referans tip
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    //new() : new'lenebilir olmalı
    public interface IEntityRepository<T> where T : class/*, IEntity*/, new()
    {
        //List<T> GetAll(Expression<Func<T, bool>> filter = null);
        //T Get(Expression<Func<T, bool>> filter);
        //int Add(T entity);
        //int Update(T entity);
        //int Delete(T entity);

        T Get(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter, string includedProperties);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        IList<T> GetList(Expression<Func<T, bool>> filter, string includedProperties);
        Dictionary<int, T> Add(T entity);
        //T AddTurnRow(T entity);
        int Update(T entity);
        IQueryable<T> Include(string[] includes);

        int AddRange(IEnumerable<T> entities);
        //IEnumerable<T> Include(params Expression<Func<T, object>>[] includes);
        //IQueryable<T> IncludeMultiple<T>(IQueryable<T> query, params Expression<Func<T, object>>[] includes);
    }
}
