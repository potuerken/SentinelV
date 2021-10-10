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
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter, string includedProperties);
        int Add(T entity);
        int Update(T entity);
    }
}
