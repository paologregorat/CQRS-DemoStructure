using Microsoft.Extensions.Configuration;

namespace CQRSSAmple.Domain.Infrasctructure.Configuration
{
    public sealed class AppCQRSSampleConfiguration
    {
        private static IConfiguration _instance;
        
        public static IConfiguration GetConfiguration()
        {
            if (_instance == null)
            {
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                _instance = builder.Build();
            }

            return _instance;
        }
    }
}