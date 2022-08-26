using System;
using CQRSSAmple.Domain.Entity;
using CQRSSAmple.Domain.EntityDTO;
using CQRSSAmple.Domain.Queries.Abstract;

namespace CQRSSAmple.Domain.Query.Business
{
    public class FirstEntityOneQuery: IQuery<EntityOne>
    {
        public Guid ID { get; private set; }
        public FirstEntityOneQuery()
        {
            
        }
    }
}