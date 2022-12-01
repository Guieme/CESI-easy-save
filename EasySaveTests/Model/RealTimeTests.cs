using Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EasySaveApp.Model;

namespace EasySaveTests.Model
{
    [Collection("Sequential")]
    public class RealTimeTests
    {
        RealTimeProgress realTimeProgress = new RealTimeProgress("SaveName", "C:/Source", "C:/Target", "ACTIVE", 25, 36, 16, 70);
        string path = @"\RealTimeLog\RealTimeLogTest.json";

        [Fact]
        public void Step00_LineChanger_IsOk()
        {
            string newText = "Block";
            int lineNumber = 1;

            File.WriteAllText(path, "OldSave");
            realTimeProgress.LineChanger(newText, path, lineNumber);
            string verifyContent = (string)File.ReadAllLines(path).GetValue(0);
            Assert.Equal(verifyContent, newText);
        }

        [Fact]
        public void Step01_AlreadyExits_IsOk()
        {
            File.Delete(path);
            File.AppendAllText(path, "[\n   }\n       \"Name\": \"Savename\",");
            int testTrue = realTimeProgress.AlreadyExists(path, "Savename");
            int testFalse = realTimeProgress.AlreadyExists(path, "Date");
            Assert.Equal(3, testTrue);
            Assert.Equal(0, testFalse);
        }

        [Fact]
        public void Step02_WritingRealTimeLog_IsOk()
        {
            string path = @"\RealTimeLog\RealTimeLogTestWritingRealTimeLog.json";
            File.Delete(path);
            realTimeProgress.WritingRealTimeLog();
            StreamReader reader = new StreamReader(@"\\RealTimeLog\RealTimeLog.json");
            string content = reader.ReadToEnd();

            string[] stringToVerify =
            {
            "[",
            "  {",
                   "\"Name\": \"SaveName\",",
                   "\"SourceFilePath\":\"C:/Updated\",",
                   "\"TargetFilePath\":\"C:/Target\",",
                   "\"State\":\"ACTIVE\",",
                   "\"TotalFilesToCopy\": 25,",
                   "\"TotalFilesSize\": 36,",
                   "\"NbFilesLeftToDo\": 16,",
                   "\"Progression\": 70",
            "  }",
            "]",
            };
            foreach (string line in stringToVerify)
                File.AppendAllText(path, line);

            string stringToVerifyContent = reader.ReadToEnd();
            Assert.Contains(stringToVerifyContent, content);

            RealTimeProgress realTimeProgressUpdate = new RealTimeProgress("SaveName", "C:/Source/Updated", "C:/Target/Updated", "ACTIVE", 25, 36, 15, 79);
            RealTimeProgress realTimeProgressAdd = new RealTimeProgress("New", "C:/Source/Add", "C:/Target/Add", "ACTIVE", 150, 50, 1568, 33);
            reader.Close();
            realTimeProgressUpdate.WritingRealTimeLog();
            realTimeProgressAdd.WritingRealTimeLog();

            string[] stringToVerifyUpdateAndAdd =
            {
            "[",
            "  {",
                   "\"Name\": \"SaveName\",",
                   "\"SourceFilePath\":\"C:/Source/Updated\",",
                   "\"TargetFilePath\":\"C:/Target/Updated\",",
                   "\"State\":\"ACTIVE\",",
                   "\"TotalFilesToCopy\": 25,",
                   "\"TotalFilesSize\": 36,",
                   "\"NbFilesLeftToDo\": 15,",
                   "\"Progression\": 79",
            "  },",
            "  {",
                   "\"Name\": \"New\",",
                   "\"SourceFilePath\":\"C:/Source/Add\",",
                   "\"TargetFilePath\":\"C:/Target/Add\",",
                   "\"State\":\"ACTIVE\",",
                   "\"TotalFilesToCopy\": 150,",
                   "\"TotalFilesSize\": 50,",
                   "\"NbFilesLeftToDo\": 1568,",
                   "\"Progression\": 33",
            "  }",
            "]",
            };
            File.Delete(path);
            foreach (string line in stringToVerifyUpdateAndAdd)
                File.AppendAllText(path, line);

            StreamReader reader1 = new StreamReader(@"\RealTimeLog\RealTimeLog.json");
            content = reader1.ReadToEnd();
            
            string stringToVerifyContentUpadteAndAdd = reader1.ReadToEnd();
            Assert.Contains(stringToVerifyContentUpadteAndAdd, content);
            reader1.Close();
        }
    }
}
