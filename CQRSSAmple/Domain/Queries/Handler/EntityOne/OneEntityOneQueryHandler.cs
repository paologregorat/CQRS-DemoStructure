using CQRSSAmple.Business.EntityOne;
using CQRSSAmple.Domain.EntityDTO;
using CQRSSAmple.Domain.Queries.Abstract;
using CQRSSAmple.Domain.Query.EntotyOne;

namespace CQRSSAmple.Domain.Queries.Handler.EntityOne
{
    public class OneEntityOneQueryHandler: IQueryHandler<OneEntityOneQuery, EntityOneDTO>
    {
        private readonly OneEntityOneQuery _query;
        private readonly EntityOneBusiness _business;
        public OneEntityOneQueryHandler(OneEntityOneQuery query, EntityOneBusiness business)
        {
            _query = query;
            _business = business;
        }
        public EntityOneDTO Get()
        {
            return _business.GetByIdDTO(_query.ID);

        }
    }
}
