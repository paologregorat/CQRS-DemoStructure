using System;
using CQRSSAmple.Domain.EntityDTO;
using CQRSSAmple.Domain.Queries.Abstract;

namespace CQRSSAmple.Domain.Query.EntotyOne
{
    public class OneEntityOneQuery: IQuery<EntityOneDTO>
    {
        public Guid ID { get; private set; }
        public OneEntityOneQuery(Guid id)
        {
            ID = id;
        }
    }
}