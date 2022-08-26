using System;
using CQRSSAmple.Business.BusinessLogic;
using CQRSSAmple.Business.EntityOne;
using CQRSSAmple.Domain.EntityDTO;
using CQRSSAmple.Domain.Queries.Abstract;
using CQRSSAmple.Domain.Query.Business;
using CQRSSAmple.Domain.Query.EntotyOne;

namespace CQRSSAmple.Domain.Queries.Handler.Business
{
    public class FirstEntityOneQueryHandler: IQueryHandler<FirstEntityOneQuery, Entity.EntityOne>
    {
        private readonly FirstEntityOneQuery _query;
        private readonly BusinessLogicBusiness _business;
        public FirstEntityOneQueryHandler(FirstEntityOneQuery query, BusinessLogicBusiness business)
        {
            _query = query;
            _business = business;
        }
        public Entity.EntityOne Get()
        {
            throw new NotImplementedException();
        }
        
        public Entity.EntityOne GetFirstEntityOne()
        {
            return _business.GetFirstEntity();

        }
    }
}
