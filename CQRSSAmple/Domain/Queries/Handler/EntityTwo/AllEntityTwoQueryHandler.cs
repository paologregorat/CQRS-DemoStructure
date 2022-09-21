using System.Collections.Generic;
using CQRSSAmple.Business.Abstract;
using CQRSSAmple.Business.EntityTwo;
using CQRSSAmple.Domain.EntityDTO;
using CQRSSAmple.Domain.Queries.Abstract;
using CQRSSAmple.Domain.Query.EntotyTwo;

namespace CQRSSAmple.Domain.Queries.Handler.EntityTwo
{
    public class AllEntityTwoQueryHandler : IQueryHandler<AllEntityTwoQuery, IEnumerable<EntityTwoDTO>>
    {
        private readonly IEntityTwoBusiness _business;

        public AllEntityTwoQueryHandler(IEntityTwoBusiness business)
        {
            _business = business;
        }

        public IEnumerable<EntityTwoDTO> Get()
        {
            return _business.GetAllDTO();
        }
        
        
    }

}
