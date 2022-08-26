using System.Collections.Generic;
using CQRSSAmple.Business.EntityOne;
using CQRSSAmple.Domain.EntityDTO;
using CQRSSAmple.Domain.Queries.Abstract;
using CQRSSAmple.Domain.Query.EntotyOne;

namespace CQRSSAmple.Domain.Queries.Handler.EntityOne
{
    public class AllEntityOneQueryHandler : IQueryHandler<AllEntityOneQuery, IEnumerable<EntityOneDTO>>
    {
        private readonly EntityOneBusiness _business;

        public AllEntityOneQueryHandler(EntityOneBusiness business)
        {
            _business = business;
        }

        public IEnumerable<EntityOneDTO> Get()
        {
            return _business.GetAllDTO();
        }
        
        
    }

}
