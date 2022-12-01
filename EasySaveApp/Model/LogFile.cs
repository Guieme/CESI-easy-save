using System;

namespace EasySaveApp.Model
{
    public class LogFile : Log
    {
        // It's all of our properties (data)
        public string Name { get; set; }
        public string FileSource { get; set; }
        public string FileTarget { get; set; }
        public string DestPath { get; set; }
        public long FileSize { get; set; }
        public double FileTransferTime { get; set; }
        public DateTime Time { get; set; }
        public int CryptingTime { get; set; }

        // It's the constructor 
        public LogFile() { }
        public LogFile(string name, string fileSource, string fileTarget, string destPath, long fileSize, double fileTransferTime, DateTime time)
        {
            Name = name;
            FileSource = fileSource;
            FileTarget = fileTarget;
            DestPath = destPath;
            FileSize = fileSize;
            FileTransferTime = fileTransferTime;
            Time = time;
        }
    }
}
