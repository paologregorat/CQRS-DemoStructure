using System;
using CQRSSAmple.Domain.EntityDTO;
using CQRSSAmple.Domain.Queries.Abstract;

namespace CQRSSAmple.Domain.Query.EntotyTwo
{
    public class OneEntityTwoQuery: IQuery<EntityTwoDTO>
    {
        public Guid ID { get; private set; }
        public OneEntityTwoQuery(Guid id)
        {
            ID = id;
        }
    }
}