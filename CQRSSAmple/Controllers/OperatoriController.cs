using System;
using System.Reflection;
using System.Threading.Tasks;
using CQRSSAmple.ActionLog;
using CQRSSAmple.Business.Abstract;
using CQRSSAmple.Business.Operatori;
using CQRSSAmple.Domain.Command;
using CQRSSAmple.Domain.Command.Handler.Operatori;
using CQRSSAmple.Domain.Infrasctructure;
using CQRSSAmple.Log;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRSSAmple.Controllers
{
    [Route("")]
    [Authorize] 
    public class OperatoriController : WebControllerBase
    {
        private readonly OperatoriBusiness _business;
        public OperatoriController(IOperatoriBusiness business) 
        {
            _business = (OperatoriBusiness) business;
        }
        
        [Route("v1/operatori/login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Logon()
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                //LogAccess(origin);
                var body = JsonBody().Result;
                var userName = (string) body.Username;
                var password = (string) body.Password;
            
                var command = new CreateTokenCommand(userName, password);
          
                var handler = OperatoreCommandHandlerFactory.Build(command, _business);
                var response = handler.Execute();
                if (response.Success)
                {
                    var operation = new ActionLog.ActionLog();
                    operation.Data = DateTime.UtcNow;
                    operation.ActionType = LogActionType.Logon;
                    operation.EntityType = LogEntityType.Operator;
                    operation.EntityName = "Operator";
                    operation.CreatedDate = DateTime.UtcNow;
                    operation.PerformingUser = _business.GetUtente(userName, password).UserName;
                    operation.PerformingGuid = _business.GetUtente(userName, password).ID.ToString();
                    await ActionLogDbEntryPointFactory.GetMongoDbEntryPoint().CreateAsync(operation);
                    return Ok(response.Message);
                }

                throw new Exception("Login fallito");
            }
            catch (Exception e)
            {
                //LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
        }

        [Route("v1/operatori/getlog")]
        [HttpGet]
        public async Task<IActionResult> GetLog()
        {
            var str = LoggerHelper.GetInsance().GetLogTxt();
            return Ok(str);
        }
        
    }
}
