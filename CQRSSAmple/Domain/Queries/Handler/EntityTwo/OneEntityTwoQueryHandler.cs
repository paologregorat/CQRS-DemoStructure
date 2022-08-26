using CQRSSAmple.Business.EntityTwo;
using CQRSSAmple.Domain.EntityDTO;
using CQRSSAmple.Domain.Queries.Abstract;
using CQRSSAmple.Domain.Query.EntotyTwo;

namespace CQRSSAmple.Domain.Queries.Handler.EntityTwo
{
    public class OneEntityTwoQueryHandler: IQueryHandler<OneEntityTwoQuery, EntityTwoDTO>
    {
        private readonly OneEntityTwoQuery _query;
        private readonly EntityTwoBusiness _business;
        public OneEntityTwoQueryHandler(OneEntityTwoQuery query, EntityTwoBusiness business)
        {
            _query = query;
            _business = business;
        }
        public EntityTwoDTO Get()
        {
            return _business.GetByIdDTO(_query.ID);

        }
    }
}
