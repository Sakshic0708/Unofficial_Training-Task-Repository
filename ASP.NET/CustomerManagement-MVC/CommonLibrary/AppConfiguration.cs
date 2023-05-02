using Microsoft.Extensions.Configuration;

namespace CommonLibrary
{
    public static class AppConfiguration
    {
        public static string ConnectionString = string.Empty;
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

            ConnectionString = root.GetSection("DatabaseSettings").GetSection("ConnectionString").Value;
            DatabaseName = root.GetSection("DatabaseSettings").GetSection("DatabaseName").Value;
            ValidAudiences = root.GetSection("JWT").GetSection("ValidAudience").Value;
            ValidIssuers = root.GetSection("JWT").GetSection("ValidIssuer").Value;
            SecretKey = root.GetSection("JWT").GetSection("Secret").Value;

        }
    }
}
