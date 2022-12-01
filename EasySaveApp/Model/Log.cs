using System;
using System.Globalization;
using System.IO;
using System.Text.Json;
using EasySaveApp.Exceptions;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Linq;
using System.Xml.Serialization;
using System.Xml;
using System.Threading;

namespace EasySaveApp.Model
{
    public class Log
    {
        private static Semaphore IsWritingLog = new Semaphore(1,1);
        // We create a private class to format the Json file with the DateTime.
        private class JsonDateTimeConverter : JsonConverter<DateTime>
        {
            public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return DateTime.Parse(reader.GetString());
            }

            public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString("dd/MM/yyyy hh:mm:ss"));
            }
        }
        public static void WriteLog(LogFile logFile, bool xmlOrJsonFile)
        {
            LogPath logPath;
            if (!xmlOrJsonFile)
            {
                // Import new instance of LogFile & LogPath Class
                logPath = new LogPath($@"{BackupManagment.Location}\logs\", DateTime.Now.ToString("ddMMyyyy"), "_log.json");
                // We Serialize in Json format our all data
                var options = new JsonSerializerOptions { WriteIndented = true };
                options.Converters.Add(new JsonDateTimeConverter());
                var jsonString = JsonSerializer.Serialize(logFile, options);

                // Condition : if the file exists, we add the new save at all, else the file will be create with the actual date.           
                if (File.Exists(logPath.CompleteLogFilePath))
                {
                    IsWritingLog.WaitOne();
                    File.AppendAllText(logPath.CompleteLogFilePath, ",\n" + jsonString);
                    IsWritingLog.Release();
                }

                else
                {
                    if (Directory.Exists(logPath.LogPathFolder))
                    {
                        IsWritingLog.WaitOne();
                        File.WriteAllText(logPath.CompleteLogFilePath, jsonString);
                        IsWritingLog.Release();
                    }
                    else
                        throw new FolderExistsException("The log folder doesn't exist");
                }
            }
            else
            {
                logPath = new LogPath($@"{BackupManagment.Location}\logs\", DateTime.Now.ToString("ddMMyyyy"), "_log.xml");
                XmlSerializer option = new XmlSerializer(logFile.GetType());
                if (File.Exists(logPath.CompleteLogFilePath))
                {
                    IsWritingLog.WaitOne();
                    var f = File.Open(logPath.CompleteLogFilePath, FileMode.Append);
                    option.Serialize(f, logFile);
                    f.Close();
                    IsWritingLog.Release();
                }
                else
                {
                    IsWritingLog.WaitOne();
                    FileStream f = File.Create(logPath.CompleteLogFilePath);
                    option.Serialize(f, logFile);
                    f.Close();
                    IsWritingLog.Release();
                }
            }
        }
    }
}
