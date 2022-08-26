using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using CQRSSAmple.Business.Abstract;
using CQRSSAmple.Business.EntityOne;
using CQRSSAmple.Domain.EntityDTO;
using CQRSSAmple.Domain.Queries.Handler.EntityOne;
using CQRSSAmple.Domain.Query.EntotyOne;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRSSAmple.Controllers
{
    [Authorize] 
    [Route("")]
    public class EntityOneController : WebControllerBase
    {
        private readonly EntityOneBusiness _business;

        public EntityOneController(IEntityOneBusiness business)
        {
            _business = (EntityOneBusiness)business;
        }

        [HttpGet]
        [Route("v1/entitiesone")]
        public async Task<IActionResult> GetAll()
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var query = new AllEntityOneQuery();
                var handler = EntityOneQueryHandlerFactory.Build(query, _business);
                var res = (List<EntityOneDTO>) handler.Get();
                return Ok(res);
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
        }
    }
}