using System.Collections.Generic;
using CQRSSAmple.Business.BusinessLogic;
using CQRSSAmple.Business.EntityOne;
using CQRSSAmple.Domain.EntityDTO;
using CQRSSAmple.Domain.Queries.Abstract;
using CQRSSAmple.Domain.Queries.Handler.EntityOne;
using CQRSSAmple.Domain.Query.Business;
using CQRSSAmple.Domain.Query.EntotyOne;

namespace CQRSSAmple.Domain.Queries.Handler.Business
{
    public static class BusinessQueryHandlerFactory
    {
        public static IQueryHandler<FirstEntityOneQuery, Entity.EntityOne> Build(FirstEntityOneQuery query, BusinessLogicBusiness business)
        {
            return new FirstEntityOneQueryHandler(query, business);
        }
    }
}