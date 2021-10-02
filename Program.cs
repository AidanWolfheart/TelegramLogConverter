using System;
using System.IO;

namespace TelegramLogConverter
{
    public static class Program
    {
        public static bool CheckFilePath(string path)
        {
            bool exists = File.Exists(path);
            if (!exists) Console.WriteLine("File does not exist. Please try a different path."); 

            return exists;
        }
        private static void Execute()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Enter 'exit' to quit or the path to log JSON file: ");
                var command = Console.ReadLine();

                if (command == "exit")
                {
                    exit = true;
                    continue;
                }

                var path = command;

                var timestamp = DateTime.Now.ToString(Config.TimestampFormat);
                var logName = Config.IncludeTimestampInName ? Config.LogName + timestamp : Config.LogName;

                if (!CheckFilePath(path)) continue;

                TelegramLogConverter.CreateTextFileFromJson(File.ReadAllText(path), logName, Config.LogResultFormat);
            }
        }

        public static void Main(string[] args)
        {
            Execute();
        }
    }
}
