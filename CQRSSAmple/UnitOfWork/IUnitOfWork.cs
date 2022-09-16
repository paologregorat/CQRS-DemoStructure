using System;
using CQRSSAmple.Domain.Entity;
using CQRSSAmple.Repository;

namespace CQRSSAmple.UnitOfWork
{
    public interface IUnitOfWork<TDbContext> where TDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        IGenericRepository<Operatore, Guid> OperatoreRepository { get; }
        int Save();
    }
}