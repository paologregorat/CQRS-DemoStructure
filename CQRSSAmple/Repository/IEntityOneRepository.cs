using System;
using CQRSSAmple.Domain.Entity;

namespace CQRSSAmple.Repository
{
    public interface IEntityOneRepository  : IGenericRepository<EntityOne, Guid>
    {
        
    }
}