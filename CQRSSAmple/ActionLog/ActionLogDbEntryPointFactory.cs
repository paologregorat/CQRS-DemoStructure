using CQRSSAmple.Domain.Infrasctructure.Configuration;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Configuration;

namespace CQRSSAmple.ActionLog
{
    public sealed class ActionLogDbEntryPointFactory
    {
        private static IActionLogDbEntryPoint _instance;
        public static IActionLogDbEntryPoint GetMongoDbEntryPoint()
        {
            if (_instance == null)
            {
                var actionLogDbType =(string) AppCQRSSampleConfiguration.GetConfiguration().GetValue(typeof(string),"ActionLogDbType");
                var actionLogDbIsDummy =(bool) AppCQRSSampleConfiguration.GetConfiguration().GetValue(typeof(bool),"ActionLogDbIsDummy");

                switch (actionLogDbType)
                {
                    case "Mongo": 
                        if (!actionLogDbIsDummy)
                        {
                            return new MongoDbEntryPoint ();
                        }
                        else
                        {
                            return new MongoDummyEntryPoint ();
                        }
                }

            }
            return _instance;
        }
    }
}