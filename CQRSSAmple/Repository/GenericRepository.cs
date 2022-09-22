using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CQRSSAmple.Domain.Infrasctructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;


//https://github.com/DeVLearninGRepo/MyReservation
namespace CQRSSAmple.Repository
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        private readonly EntityContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(EntityContext  context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        
        public TEntity GetById(TKey id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> Get( Expression<Func<TEntity, bool>> predicate = null, bool? asTraking = true, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (asTraking.HasValue && asTraking.Value == false)
            {
                query.AsNoTracking();
            }
            
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (!string.IsNullOrEmpty(includeProperties) && !string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).AsEnumerable();
            }
            else
            {
                return query.AsEnumerable();
            }
        }

        public void Delete(TKey id)
        {
            if (id == null) throw new ArgumentNullException("id");

            var entityToDelete = GetById(id);

            if (entityToDelete == null) throw new Exception("Entity not found");

            _dbSet.Remove(entityToDelete);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Attach(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);

            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}