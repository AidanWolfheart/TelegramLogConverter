using System.Configuration;

namespace TelegramLogConverter
{
    public static class Config
{   
        public static string LogResultFormat { get { return ConfigurationManager.AppSettings.Get("LogResultFormat"); } }
        public static string LogName { get { return ConfigurationManager.AppSettings.Get("LogName"); } }
        public static string TimestampFormat { get { return ConfigurationManager.AppSettings.Get("TimestampFormat"); } }

        private static bool _includeTimestampInName;
        public static bool IncludeTimestampInName 
        { get 
            { 
                bool.TryParse(ConfigurationManager.AppSettings.Get("IncludeTimestampInName"), out _includeTimestampInName);
                return _includeTimestampInName;
            } 
        }
    }
}
