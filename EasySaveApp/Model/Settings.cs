using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasySaveApp.Model
{
    public class Settings
    {
        //this attribute stocks the language necessary for the menu
        public string Language;
        public List<string> ExtensionsToCrypt;
        public List<string> Business;
        public List<string> PriorityFiles;
        public bool xmlLogs;
        public long InputFileSize;
        //Constructor, it setup the language by default it take in parameter
        private Settings() {
            xmlLogs = true;
            Language = "English";
        }

        //Singleton
        private static Settings Instance;
        public static Settings GetSettings()
        {
            if (Instance == null)
                Instance = new Settings();
            return Instance;
        }

        //WriteExtensionFile write extensions who have to be crypted in it specified logfile
        public void WriteExtensionFile()
        {
            var path = BackupManagment.Location + @"\ExtensionToEncrypt\ExtensionsToEncrypt.txt";
            File.Delete(path);
            File.WriteAllLines(path, ExtensionsToCrypt);
        }

        //WriteBusinessFile write softwares in it specified logfile
        public void WriteBusinessFile()
        {
            var path = Path.Combine(BackupManagment.Location + @"\BusinessSoftware\BusinessSoftware.txt");
            File.Delete(path);
            File.WriteAllLines(path, Business);
        }

        //WritePriorityFile write extensions who have to be priorize in it specified logfile
        public void WritePriorityFile()
        {
            var path = BackupManagment.Location + @"\PriorityFile\PriorityFile.txt";
            File.Delete(path);
            File.WriteAllLines(path, PriorityFiles);
        }
        public void WriteInputFileSize()
        {
            var path = BackupManagment.Location + @"\BigFile\BigFile.txt";
            File.Delete(path);
            File.WriteAllText(path, InputFileSize.ToString());
        }
    }
}
