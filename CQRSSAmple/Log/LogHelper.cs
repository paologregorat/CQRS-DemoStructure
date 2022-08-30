using System;
using System.IO;
using System.Text;
using CQRSSAmple.ActionLog;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CQRSSAmple.Log
{
    public class LoggerHelper
    {

        private static LoggerHelper _instance;
        private static ILogger<Program> _logger;

        private LoggerHelper()
        { 
            var serilogLogger = new LoggerConfiguration()
                .WriteTo.File("log.txt",shared: true, rollingInterval:RollingInterval.Day)
                .WriteTo.Seq("http://localhost:5341")
                .WriteTo.Console()
                .CreateLogger();

            //Create a logger factory
            var loggerFactory = new LoggerFactory().AddSerilog(serilogLogger);
            _logger = loggerFactory.CreateLogger<Program>();

            
        }

        public static LoggerHelper GetInsance()
        {
            if (_instance == null)
            {
                _instance = new LoggerHelper();
            }

            return _instance;
        }
        
        public  ILogger<Program> GetLogger()
        {
            return _logger;
        }

        public string GetLogTxt()
        {
            byte[] buffer = null;
            using (var stream = File.Open("log.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);
                return Encoding.UTF8.GetString(buffer);
            }
        }
        
        public static void LogMongoAccess(Guid userID, LogEntityType logEntityType, string entityName, string origin)
        {
            var operation = new ActionLog.ActionLog();
            operation.Data = DateTime.UtcNow;
            operation.ActionType = LogActionType.LogAccess;
            operation.EntityType = logEntityType;
            operation.EntityName = entityName;
            operation.CreatedDate = DateTime.UtcNow;
            operation.PerformingGuid = userID.ToString();
            operation.Data = origin;
            
            ActionLogDbEntryPointFactory.GetMongoDbEntryPoint().CreateAsync(operation);
        }
        
        public static void LogMongo(ActionLog.ActionLog actionLog)
        {
            ActionLogDbEntryPointFactory.GetMongoDbEntryPoint().CreateAsync(actionLog);
        }
        
        public static void LogError(Guid uuserID, string origin, string error)
        {
            var logger = LoggerHelper.GetInsance().GetLogger();
            string method = string.Format("{0} {1} {2}", "Start: ",  origin, error); 
            logger.LogInformation(uuserID.ToString() + " - " + method);
        }
    }
}