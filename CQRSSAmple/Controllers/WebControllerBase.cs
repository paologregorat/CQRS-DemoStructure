using System.Text.Json;
using System.Threading.Tasks;
using CQRSSAmple.Business.Abstract;
using CQRSSAmple.Business.Operatori;
using CQRSSAmple.Domain.Entity;
using CQRSSAmple.Domain.Infrasctructure;
using CQRSSAmple.Domain.Utility;
using CQRSSAmple.Log;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CQRSSAmple.Controllers
{
    public class WebControllerBase : ControllerBase
    {
        protected async Task<dynamic> JsonBody () {
            var result = await JsonDocument.ParseAsync (Request.Body);
            return new JsonDynamicObject {
                RealObject = result.RootElement
            };
        }

        
    }
}