using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CQRSSAmple.Domain.Entity;
using CQRSSAmple.Domain.Infrasctructure;

namespace CQRSSAmple.Repository
{
    public class EntityOneRepository : GenericRepository<EntityOne, Guid>, IEntityOneRepository
    {
        public EntityOneRepository(EntityContext context) : base(context)
        {

        }
    }
}