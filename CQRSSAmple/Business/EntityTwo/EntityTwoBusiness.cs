using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CQRSSAmple.Business.Abstract;
using CQRSSAmple.Domain.Command;
using CQRSSAmple.Domain.Entity;
using CQRSSAmple.Domain.EntityDTO;
using CQRSSAmple.Domain.Infrasctructure;
using CQRSSAmple.Domain.Queries.Serializer.EntityTwo;
using Microsoft.EntityFrameworkCore;

namespace CQRSSAmple.Business.EntityTwo
{
    public class EntityTwoBusiness : IEntityTwoBusiness
    {
        private EntityTwoSerializer _serializer;
        private EntityContext _context;

        public EntityTwoBusiness(EntityContext context, IEntityTwoSerializer serializer)
        {
            _serializer = (EntityTwoSerializer)serializer;
            _context = context;
        }
        
        public DbSet<Domain.Entity.EntityTwo> GetAll() =>  _context.EntitiesTwo;
        public List<EntityTwoDTO> GetAllDTO() => _serializer.SerializeList(GetAll());

        public List<Domain.Entity.EntityTwo> Search(Expression<Func<Domain.Entity.EntityTwo, bool>> whereClause) =>  _context.EntitiesTwo.Where(whereClause).ToList();
        
        public List<EntityTwoDTO> SearchDTO(Expression<Func<Domain.Entity.EntityTwo, bool>> whereClause) =>  _serializer.SerializeList(Search(whereClause));

        public Domain.Entity.EntityTwo GetById(System.Guid id) => _context.EntitiesTwo.FirstOrDefault(c => c.ID == id);

        public EntityTwoDTO GetByIdDTO(System.Guid id) => _serializer.SerializeSingle(GetById(id));
        

        public CommandResponse Save(SaveEntityTwoCommand command)
        {
            var response = new CommandResponse()
            {
                Success = false
            };
            
            //if (Validator<Corso>.CheckEntity(e =>
            //{
            //    if (string.IsNullOrEmpty(e.Nome))
            //    {
            //        return false;
            //    }
//
            //    return true;
            //}, command.Corso) == false)
            //{
            //    response.Success = false;
            //    response.Message ="Nome obbligatorio";
            //    return response;
            //}
            
            var toUpdate = _context.EntitiesTwo.FirstOrDefault(e => e.ID == command.EntityTwo.ID);
            if (toUpdate == default)
            {
                _context.EntitiesTwo.Add(command.EntityTwo);
            } else {
                
                _context.Entry(toUpdate).CurrentValues.SetValues(command.EntityTwo);
            }
            
            _context.SaveChanges();
            response.ID = command.EntityTwo.ID;
            response.Success = true;
            response.Message = "Entity salvata.";
            
            return response;
        }
    }
}