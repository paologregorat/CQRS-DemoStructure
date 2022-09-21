using System.Collections.Generic;
using CQRSSAmple.Business.Abstract;
using CQRSSAmple.Business.EntityTwo;
using CQRSSAmple.Domain.EntityDTO;
using CQRSSAmple.Domain.Queries.Abstract;
using CQRSSAmple.Domain.Queries.Handler.EntityTwo;
using CQRSSAmple.Domain.Query.EntotyTwo;

namespace CQRSSAmple.Domain.Queries.Handler.EntityTwo
{
    public static class EntityTwoQueryHandlerFactory
    {
        public static IQueryHandler<AllEntityTwoQuery, IEnumerable<EntityTwoDTO>> Build(AllEntityTwoQuery query, IEntityTwoBusiness business)
        {
            return new AllEntityTwoQueryHandler(business);
        }

        public static IQueryHandler<OneEntityTwoQuery, EntityTwoDTO> Build(OneEntityTwoQuery query, IEntityTwoBusiness business)
        {
            return new OneEntityTwoQueryHandler(query, business);
        }
    }
}