using System;
using CQRSSAmple.Domain.Entity;
using CQRSSAmple.Domain.Infrasctructure;

namespace CQRSSAmple.Repository
{
    public class OperatoriRepository : GenericRepository<Operatore, Guid>, IOperatoriRepository
    {
        public OperatoriRepository(EntityContext context) : base(context)
        {

        }
    }
}