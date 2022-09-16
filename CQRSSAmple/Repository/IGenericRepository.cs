using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CQRSSAmple.Repository
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : class
    {
        TEntity GetById(TKey id);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        void Delete(TKey id);

        void Delete(TEntity entity);

        void Insert(TEntity entity);

        void Update(TEntity entity);

    }
}