using System.Collections.Generic;
using CQRSSAmple.Business.Abstract;
using CQRSSAmple.Business.EntityOne;
using CQRSSAmple.Domain.EntityDTO;
using CQRSSAmple.Domain.Queries.Abstract;
using CQRSSAmple.Domain.Query.EntotyOne;

namespace CQRSSAmple.Domain.Queries.Handler.EntityOne
{
    public static class EntityOneQueryHandlerFactory
    {
        public static IQueryHandler<AllEntityOneQuery, IEnumerable<EntityOneDTO>> Build(AllEntityOneQuery query, IEntityOneBusiness business)
        {
            return new AllEntityOneQueryHandler(business);
        }

        public static IQueryHandler<OneEntityOneQuery, EntityOneDTO> Build(OneEntityOneQuery query, IEntityOneBusiness business)
        {
            return new OneEntityOneQueryHandler(query, business);
        }
    }
}