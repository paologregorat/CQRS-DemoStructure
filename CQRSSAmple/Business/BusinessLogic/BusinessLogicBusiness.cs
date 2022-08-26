using System.Linq;
using CQRSSAmple.Business.Abstract;
using CQRSSAmple.Business.EntityOne;

namespace CQRSSAmple.Business.BusinessLogic
{
    public class BusinessLogicBusiness : IBusinessLogicBusiness
    {
        private readonly EntityOneBusiness _businessEntityOne;
        
        BusinessLogicBusiness(IEntityOneBusiness business)
        {
            _businessEntityOne = (EntityOneBusiness)business;
        }
        
        public Domain.Entity.EntityOne GetFirstEntity()
        {
            return _businessEntityOne.GetAll().FirstOrDefault();
        }
    }
}