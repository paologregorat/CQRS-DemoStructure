using System.Collections.Generic;
using CQRSSAmple.Business.Abstract;
using CQRSSAmple.Business.EntityOne;
using CQRSSAmple.Domain.EntityDTO;
using CQRSSAmple.Domain.Queries.Abstract;
using CQRSSAmple.Domain.Query.EntotyOne;

namespace CQRSSAmple.Domain.Queries.Handler.EntityOne
{
    public class AllEntityOneQueryHandler : IQueryHandler<AllEntityOneQuery, IEnumerable<EntityOneDTO>>
    {
        private readonly IEntityOneBusiness _business;

        public AllEntityOneQueryHandler(IEntityOneBusiness business)
        {
            _business = business;
        }

        public IEnumerable<EntityOneDTO> Get()
        {
            return _business.GetAllDTO();
        }
        
        
    }

}
