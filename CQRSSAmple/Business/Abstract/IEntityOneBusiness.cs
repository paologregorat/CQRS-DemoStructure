using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CQRSSAmple.Domain.Command;
using CQRSSAmple.Domain.Entity;
using CQRSSAmple.Domain.EntityDTO;

namespace CQRSSAmple.Business.Abstract
{
    public interface IEntityOneBusiness
    {
        public List<Domain.Entity.EntityOne> GetAll();
        public List<EntityOneDTO> GetAllDTO();

        public List<Domain.Entity.EntityOne> Search(Expression<Func<Domain.Entity.EntityOne, bool>> whereClause, bool? asTraking, Func<IQueryable<Domain.Entity.EntityOne>, IOrderedQueryable<Domain.Entity.EntityOne>> orderBy, string includeProperties);
        
        public List<EntityOneDTO> SearchDTO(Expression<Func<Domain.Entity.EntityOne, bool>> whereClause, bool? asTraking, Func<IQueryable<Domain.Entity.EntityOne>, IOrderedQueryable<Domain.Entity.EntityOne>> orderBy, string includeProperties);

        public Domain.Entity.EntityOne GetById(System.Guid id);

        public EntityOneDTO GetByIdDTO(System.Guid id);
        
        public CommandResponse Save(SaveEntityOneCommand command);
    }
}