using Microsoft.Extensions.Configuration;
using System.IO;

namespace Esercitazione.Work.Helpers
{
    public class Config
    {
        private static IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        public static string GetConnectionString(string connStringName)
        {
            return config.GetConnectionString(connStringName);
        }
    }

}