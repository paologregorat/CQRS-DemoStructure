using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CQRSSAmple.Domain.Command;
using CQRSSAmple.Domain.Entity;
using CQRSSAmple.Domain.EntityDTO;
using Microsoft.EntityFrameworkCore;

namespace CQRSSAmple.Business.Abstract
{
    public interface IEntityTwoBusiness
    {
        public DbSet<Domain.Entity.EntityTwo> GetAll();
        public List<EntityTwoDTO> GetAllDTO();

        public List<Domain.Entity.EntityTwo> Search(Expression<Func<Domain.Entity.EntityTwo, bool>> whereClause);
        
        public List<EntityTwoDTO> SearchDTO(Expression<Func<Domain.Entity.EntityTwo, bool>> whereClause);

        public Domain.Entity.EntityTwo GetById(System.Guid id);

        public EntityTwoDTO GetByIdDTO(System.Guid id);
        
        public CommandResponse Save(SaveEntityTwoCommand command);

    }
}