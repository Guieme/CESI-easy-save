using System.IO;

namespace EasySaveApp.Model
{
    public class LogPath : Log
    {
        // It's all of our properties (data)
        public string LogPathFolder { get; set; }
        private string DateAsText { get; set; }
        private string LogFileNameWithoutDate { get; set; }
        private string LogFileName { get; set; }
        public string CompleteLogFilePath { get; set; }

        // It's the constructor
        public LogPath(string logPathFolder, string dateAsText, string logFileNameWithoutDate)
        {
            LogPathFolder = logPathFolder;
            DateAsText = dateAsText;
            LogFileNameWithoutDate = logFileNameWithoutDate;
            LogFileName = DateAsText + LogFileNameWithoutDate;
            CompleteLogFilePath = Path.Combine(LogPathFolder, LogFileName);
        }
    }
}
