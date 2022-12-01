using EasySaveApp.Model;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.IO;
using Xunit;
using System.Collections.Generic;
using System.Text.Json;

namespace EasySaveTests
{
    [Collection("Sequential")]
    public class LogFileTest
    {
        [Fact]
        public void Step01_CreateJsonLogFile_IsOk()
        {
            // Arrange
            LogPath logPath = new LogPath(@"\log\", DateTime.Now.ToString("ddMMyyyy"), "_log.json");
           
            // Act
            FileInfo fileInfo = new FileInfo(logPath.CompleteLogFilePath);
            File.WriteAllText(logPath.CompleteLogFilePath, "sample text");

            // Assert
            Assert.True(File.Exists(logPath.CompleteLogFilePath));
            Assert.NotEqual(0, fileInfo.Length);

           
        }

        [Fact]
        public void Step02_AnalyzeLogFile_IsOk()
        {
            EasySaveApp.ViewModel.BackupManagment.GetBackupManagment().InitSoft();
            // Arrange
            LogPath logPath = new LogPath(@"\logs", DateTime.Now.ToString("ddMMyyyy"), "_log.json");
            LogFile logFile = new LogFile("Save3", @"C:\zSource", @"C:\zTarget", "", 1704592, 58, DateTime.Now);

            Log.WriteLog(logFile, false);

            var Name = logFile.Name.ToString();
            var DestPath = logFile.DestPath.ToString();
            var FileSize = logFile.FileSize.ToString();
            var FileTransferTime = logFile.FileTransferTime.ToString();
            var Time = logFile.Time.ToString();

            // Act + Assert
            Assert.Contains(Name, File.ReadAllText(logPath.CompleteLogFilePath));
            Assert.Contains(@"C:\\zSource", File.ReadAllText(logPath.CompleteLogFilePath));
            Assert.Contains(@"C:\\zTarget", File.ReadAllText(logPath.CompleteLogFilePath));
            Assert.Contains(DestPath, File.ReadAllText(logPath.CompleteLogFilePath));
            Assert.Contains(FileSize, File.ReadAllText(logPath.CompleteLogFilePath));
            Assert.Contains(FileTransferTime, File.ReadAllText(logPath.CompleteLogFilePath));
            Assert.Contains(Time.Substring(0, 10), File.ReadAllText(logPath.CompleteLogFilePath));

            File.Delete(logPath.CompleteLogFilePath);
        }

        [Fact]
        public void Step03_FileError_IsOk()
        {
            EasySaveApp.ViewModel.BackupManagment.GetBackupManagment().InitSoft();
            // Arrange
            LogPath logPath = new LogPath(@"\logs", DateTime.Now.ToString("ddMMyyyy"), "_log.json");
            LogFile logFile = new LogFile("Save3", @"C:\zSource", @"C:\zTarget", "", 1704592, 58, DateTime.Now);

            // Act
            Log.WriteLog(logFile, false);
            var Qql = File.ReadAllText(logPath.CompleteLogFilePath);

            Log.WriteLog(logFile, false);
            var Qql2 = File.ReadAllText(logPath.CompleteLogFilePath);

            // Assert
            Assert.NotEqual(Qql, Qql2);
            Assert.Contains(Qql, Qql2);

            File.Open(logPath.CompleteLogFilePath, FileMode.Append).DisposeAsync();
            File.Delete(logPath.CompleteLogFilePath);
        }
    }
}
