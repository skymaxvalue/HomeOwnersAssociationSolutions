using Microsoft.Extensions.Configuration;

namespace DAL.Helper
{
    public class ConfigurationHelper
    {
        static IConfigurationRoot config;
        static ConfigurationHelper()
        {
            config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
        }

        static string conf = "";
        public static string GetConfig(string key) 
        {
            conf = config[key];
            return conf;
        }
    }
}
