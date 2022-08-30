using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using CQRSSAmple.ActionLog;
using CQRSSAmple.Business.Abstract;
using CQRSSAmple.Business.EntityOne;
using CQRSSAmple.Domain.EntityDTO;
using CQRSSAmple.Domain.Infrasctructure.Authorization;
using CQRSSAmple.Domain.Queries.Handler.EntityOne;
using CQRSSAmple.Domain.Query.EntotyOne;
using CQRSSAmple.Log;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;

namespace CQRSSAmple.Controllers
{
    [Authorize] 
    [Route("v1/entitiesone")]
    public class EntityOneController : ControllerBase
    {
        private readonly EntityOneBusiness _business;

        public EntityOneController(IEntityOneBusiness business)
        {
            _business = (EntityOneBusiness)business;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                LoggerHelper.LogMongoAccess(User.ID(), LogEntityType.Operator, "Operatori", "GetAll");
                var query = new AllEntityOneQuery();
                var handler = EntityOneQueryHandlerFactory.Build(query, _business);
                var res = (List<EntityOneDTO>) handler.Get();
                return Ok(res);
            }
            catch (Exception e)
            {
                var origin = string.Format("{0}.{1}", "v1/entitiesone", "GetAll");
                LoggerHelper.LogError(User.ID(),origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
        }
    }
}