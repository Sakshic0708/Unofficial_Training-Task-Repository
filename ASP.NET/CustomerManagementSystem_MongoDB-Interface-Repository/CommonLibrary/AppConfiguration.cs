using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Configuration.Memory;

namespace CommonLibrary
{
    public static class AppConfiguration
    {
        public static string ConnectionString =  string.Empty;
        public static string DatabaseName = string.Empty;
        public static string ValidAudiences = string.Empty;
        public static string ValidIssuers = string.Empty;
        public static string SecretKey = string.Empty;

        static AppConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var currentDirectory = Directory.GetCurrentDirectory();
            
            var path = Path.Combine(currentDirectory, "appsettings.json");
            configurationBuilder.AddJsonFile($"{path}");
            var root = configurationBuilder.Build();

            ConnectionString = root.GetSection("MongoDB").GetSection("ConnectionString").Value;
            DatabaseName = root.GetSection("MongoDB").GetSection("DatabaseName").Value;
            ValidAudiences = root.GetSection("JWT").GetSection("ValidAudience").Value;
            ValidIssuers = root.GetSection("JWT").GetSection("ValidIssuer").Value;
            SecretKey = root.GetSection("JWT").GetSection("Secret").Value;

        }
    }
}
