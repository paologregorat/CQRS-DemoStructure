using System.IO;
using System.Text;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CQRSSAmple.Domain.Infrasctructure
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
    }
}