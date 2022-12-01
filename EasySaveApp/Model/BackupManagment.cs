using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EasySaveApp.ViewModel;
using Newtonsoft.Json;

namespace EasySaveApp.Model
{
    public class BackupManagment
    {
        //Location Contains the path of the project, it will be use to have differents logs
        public static string Location { get; set; }
        //Constructor
        private BackupManagment() { Location = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location); }
        
        //GetBackupManagment behove of the singleton pattern, to have only one instance of this class in the code
        public static BackupManagment GetBackupManagment()
        {
            if (Instance == null)
                Instance = new BackupManagment();
            return Instance;
        }
        //The  instance concerned
        private static BackupManagment Instance { get; set; }

        //RestoreBackup return the list of backups written in the logfile associated
        public List<Save> RestoreBackup(MainViewModel main)
        {
            string savePath = Location + $@"\Saves"; //define path of the logfile
            string fileName = "Saves.json"; //define the name of the logfile

            //this try open the file and return it, the catch return saves configured, more expetially , an empty list
            try
            {
                Directory.CreateDirectory(savePath);
                string json = File.ReadAllText(savePath + @"\" + fileName);
                return JsonConvert.DeserializeObject<List<Save>>(json);
            }
            catch (FileNotFoundException) { return main.saves; }
            catch (ArgumentNullException) { return main.saves; }
        }

        //RestoreExtensionsToCrypt put the content of logfile who contains all extensions to crypt in a attribute of settings
        public void RestoreExtensionsToCrypt()
        {
            Settings.GetSettings().ExtensionsToCrypt = File.ReadLines(Location + @"\ExtensionToEncrypt\ExtensionsToEncrypt.txt").ToList();
        }

        //RestoreBusinessSoft put the content of logfile who contains all Business software in a attribute of settings
        public void RestoreBusinessSoft()
        {
            Settings.GetSettings().Business = File.ReadLines(Location + @"\BusinessSoftware\BusinessSoftware.txt").ToList();
        }

        //RestorePriorityFiles put the content of logfile who contains all extensions to priorize in a attribute of settings
        public void RestorePriorityFiles()
        {
            Settings.GetSettings().PriorityFiles = File.ReadLines(Location + @"\PriorityFile\PriorityFile.txt").ToList();
        }
        public void RestoreBigFile()
        {
            try
            {
                Settings.GetSettings().InputFileSize = Convert.ToInt64(File.ReadAllText(Location + @"\BigFile\BigFile.txt"));
            }
            catch (FormatException)
            {
                Settings.GetSettings().InputFileSize = 0;
            }
            
        }
        public void SaveBackupList(MainViewModel main)
        {
            string savePath = Location + $@"\Saves";
            string fileName = "Saves.json";

            Directory.CreateDirectory(savePath);
            if (!File.Exists(savePath + @"\" + fileName))
                Directory.CreateDirectory(savePath);
            try
            { File.WriteAllText(savePath + @"\" + fileName, JsonConvert.SerializeObject(main.saves, Formatting.Indented)); }
            catch (UnauthorizedAccessException)
            { }

            Networking.ReceiveEvent.SendBackups();
        }
        //InitSoft initialize all logfile if they does'nt exist to memorize at and of process
        public void InitSoft()
        {
            var saveDir = Location + $@"\Saves";
            var logDir = Location + $@"\logs";
            var RealTimeDir = Location + $@"\RealTimeLog";
            var ExtensionToEncryptDir = Location + $@"\ExtensionToEncrypt";
            var BusinessSoftwareDir = Location + $@"\BusinessSoftware";
            var PriorityFilesDir = Location + $@"\PriorityFile";
            var BigFile = Location + $@"\BigFile";
            if (!Directory.Exists(saveDir))
                Directory.CreateDirectory(saveDir);
            if (!Directory.Exists(ExtensionToEncryptDir))
                Directory.CreateDirectory(ExtensionToEncryptDir);
            if (!File.Exists(ExtensionToEncryptDir + @"\ExtensionsToEncrypt.txt"))
                File.Create(ExtensionToEncryptDir + @"\ExtensionsToEncrypt.txt").Dispose();
            if (!Directory.Exists(BusinessSoftwareDir))
                Directory.CreateDirectory(BusinessSoftwareDir);
            if (!File.Exists(BusinessSoftwareDir + @"\BusinessSoftware.txt"))
                File.Create(BusinessSoftwareDir + @"\BusinessSoftware.txt").Dispose();
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);
            if (!Directory.Exists(RealTimeDir))
                Directory.CreateDirectory(RealTimeDir);
            if (!File.Exists(RealTimeDir + @"\RealTimeLog.json"))
                File.Create(RealTimeDir + @"\RealTimeLog.json").Dispose();
            if (!Directory.Exists(PriorityFilesDir))
                Directory.CreateDirectory(PriorityFilesDir);
            if (!File.Exists(PriorityFilesDir + @"\PriorityFile.txt"))
                File.Create(PriorityFilesDir + @"\PriorityFile.txt").Dispose();
            if (!Directory.Exists(BigFile))
                Directory.CreateDirectory(BigFile);
            if (!File.Exists(BigFile + @"\BigFile.txt"))
                File.Create(BigFile + @"\BigFile.txt").Dispose();
        }
    }
}
