using System.Collections.Generic;
using CQRSSAmple.Business.Abstract;
using CQRSSAmple.Business.BusinessLogic;
using CQRSSAmple.Business.EntityOne;
using CQRSSAmple.Domain.Command;
using CQRSSAmple.Domain.Command.Handler;
using CQRSSAmple.Domain.Command.Handler.EntityOne;
using CQRSSAmple.Domain.Entity;
using CQRSSAmple.Domain.EntityDTO;
using CQRSSAmple.Domain.Queries.Handler.Business;
using CQRSSAmple.Domain.Queries.Handler.EntityOne;
using CQRSSAmple.Domain.Query.Business;
using CQRSSAmple.Domain.Query.EntotyOne;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSSAmple.Client
{
    public class Client
    {
        private readonly EntityOneBusiness _businessEntityOne;
        private readonly BusinessLogicBusiness _businessLogic;

        public Client(IEntityOneBusiness businessEntityOne, IBusinessLogicBusiness businessLogic)
        {
            _businessEntityOne = (EntityOneBusiness)businessEntityOne;
            _businessLogic = (BusinessLogicBusiness)businessLogic;
        }
        
        public void Execute()
        {
            
            
            
            var query = new AllEntityOneQuery();
            var handler = EntityOneQueryHandlerFactory.Build(query, _businessEntityOne);
            var res = (List<EntityOneDTO>) handler.Get();
            
            var command = new SaveEntityOneCommand(new EntityOne());
            var handler1 = EntityOneCommandHandlerFactory.Build(command, _businessEntityOne);
            var response = handler1.Execute();

            var query2 = new FirstEntityOneQuery();
            var handler2 = BusinessQueryHandlerFactory.Build(query2, _businessLogic);
            var res2 = handler2.Get();
        }
        
    }
}