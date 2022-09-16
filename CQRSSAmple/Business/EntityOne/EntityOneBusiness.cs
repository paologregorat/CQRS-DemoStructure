using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using CQRSSAmple.Business.Abstract;
using CQRSSAmple.Domain.Command;
using CQRSSAmple.Domain.Entity;
using CQRSSAmple.Domain.EntityDTO;
using CQRSSAmple.Domain.Infrasctructure;
using CQRSSAmple.Domain.Queries.Serializer.EntityOne;
using CQRSSAmple.Repository;
using Microsoft.EntityFrameworkCore;

namespace CQRSSAmple.Business.EntityOne
{
    public class EntityOneBusiness : IEntityOneBusiness
    {
        private EntityOneSerializer _serializer;
        private readonly EntityOneRepository _repository;

        public EntityOneBusiness(IEntityOneSerializer serializer, IEntityOneRepository repository)
        {
            _repository = (EntityOneRepository) repository;
            _serializer = (EntityOneSerializer)serializer;
        }
        
        public List<Domain.Entity.EntityOne> GetAll() =>  _repository.Get().ToList();
        public List<EntityOneDTO> GetAllDTO() => _serializer.SerializeList(GetAll());

        public List<Domain.Entity.EntityOne> Search(Expression<Func<Domain.Entity.EntityOne, bool>> whereClause) =>  _repository.Get(whereClause).ToList();
        
        public List<EntityOneDTO> SearchDTO(Expression<Func<Domain.Entity.EntityOne, bool>> whereClause) =>  _serializer.SerializeList(Search(whereClause));

        public Domain.Entity.EntityOne GetById(System.Guid id) => _repository.GetById(id);

        public EntityOneDTO GetByIdDTO(System.Guid id) => _serializer.SerializeSingle(GetById(id));
        

        public CommandResponse Save(SaveEntityOneCommand command)
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
            
            var toUpdate = _repository.GetById(command.EntityOne.ID);
            if (toUpdate == default)
            {
                //_context.EntitiesOne.Add(command.EntityOne);
                _repository.Insert(command.EntityOne);
            } else {
                
                //_context.Entry(toUpdate).CurrentValues.SetValues(command.EntityOne);
                _repository.Update(command.EntityOne);
            }
            
            //_context.SaveChanges();
            response.ID = command.EntityOne.ID;
            response.Success = true;
            response.Message = "Entity salvata.";
            
            return response;
        }
    }
}