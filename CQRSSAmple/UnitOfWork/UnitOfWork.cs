using System;
using CQRSSAmple.Domain.Entity;
using CQRSSAmple.Domain.Infrasctructure;
using CQRSSAmple.Repository;

namespace CQRSSAmple.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork<EntityContext>, IDisposable
    {
        private readonly EntityContext _context;
        private bool disposed = false;
        private IGenericRepository<Operatore, Guid> _operatoreRepository;
        private IGenericRepository<EntityOne, Guid> _entityOneRepository;

        public IGenericRepository<EntityOne, Guid> EntityOneRepository
        {
            get
            {
                return _entityOneRepository ?? (_entityOneRepository = new GenericRepository<EntityOne, Guid>(_context));
            }
        }
        

        public IGenericRepository<Operatore, Guid> OperatoreRepository
        {
            get
            {
                return _operatoreRepository ?? (_operatoreRepository = new GenericRepository<Operatore, Guid>(_context));
            }
        }

        public UnitOfWork(EntityContext context)
        {
            _context = context;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}