using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TelegramLogConverter
{
    public static class TelegramLogConverter
    {
        public static StreamWriter CreateTextFileFromJson(string logJson, string logName, string logResultFormat)
        {
            return CreateTextFileFromLines(ConvertObjectToList(ConvertJsonToObject(logJson), logResultFormat), logName);
        }

        public static StreamWriter CreateTextFileFromLines(List<string> lines, string logName)
        {
            if (!lines.Any())
            {
                return null;
            }

            using StreamWriter file = new StreamWriter(string.Format("{0}.txt", logName));

            foreach (var line in lines)
            {
                file.WriteLine(line);
                Console.Write(".");
            }

            Console.WriteLine("Done. Saved at {0}.txt", logName);
            return file;
        }

        public static dynamic ConvertJsonToObject(string logJson)
        {
            try
            {
                return JsonConvert.DeserializeObject<dynamic>(logJson);
            }
            catch (Exception)
            {
                Console.WriteLine("Unreadable file.");
            }

            return null;
        }

        public static List<string> ConvertObjectToList(dynamic log, string logResultFormat)
        {
            var logLines = new List<string>();

            try
            {
                foreach (var message in log["messages"])
                {
                    if (message["type"] != "message") continue;

                    var photoKey = "photo";
                    if (message.ContainsKey(photoKey))
                    {
                        message["text"] = message[photoKey];
                    }

                    var fileKey = "file";
                    if (message.ContainsKey(fileKey))
                    {
                        message["text"] = message[fileKey];
                    }

                    logLines.Add(string.Format(logResultFormat.Replace("{date}", "{0}").Replace("{from}", "{1}").Replace("{text}", "{2}"), message["date"], message["from"], message["text"]));

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid JSON format.");
            }          

            return logLines;
        }
    }
}
