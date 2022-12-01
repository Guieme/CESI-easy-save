using EasySaveApp.Exceptions;
using EasySaveApp.View;
using EasySaveApp.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Management;
using System.Threading;
using System.Windows.Controls;
using System.Windows;

namespace EasySaveApp.Model
{
    public class Save
    {
        private static bool IsPriorityRemaning { get; set; }
        private static Semaphore PriorityFilesSemaphore = new Semaphore(1, 1);
        private static Semaphore BigFileSemaphore = new Semaphore(1, 1);
        public string Target { get; set; }
        public string Source { get; set; }
        public bool Cancel { get; set; }
        public bool IsStatePlay { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        private List<Files> FilesToSave { get; set; }
        private long TotalSizeOfFilesToSave { get; set; }
        private static bool BigFileState { get; set; }
        //private long BigFileSize { get; set; }

        // Contructor itinialise all Save attributes an scan for first time the Target Path
        public Save(string backupTarget, string source, string name, string type)
        {
            Target = backupTarget;
            Source = source;
            Name = name;
            Type = type;
            FilesToSave = new List<Files>();
        }
        //Public methods
        //StartSave saves backups in function of their extension, for crypt or priorize
        public void StartSave(bool xmlOrJsonLog)
        {
            FilesToSave.Clear();
            IsStatePlay = true;
            Cancel = false;
            GetAllFilesToBackup();
            List<Files> priorityFiles = GetPriorityFiles();
            List<string> extensionsToEncrypt = Settings.GetSettings().ExtensionsToCrypt;

            var progress = new RealTimeProgress(Name, Source, Target, "ACTIVE", priorityFiles.Count + FilesToSave.Count, TotalSizeOfFilesToSave, FilesToSave.Count, 0);

            List<LogFile> logfilesTocrypt = new List<LogFile>();
            List<LogFile> logFiles = new List<LogFile>();

            var Process = new Process(); //initialisation du process
            Process.StartInfo.FileName = (string)Environment.GetEnvironmentVariable("CryptoSoft.exe");
            Process.StartInfo.CreateNoWindow = true;
            bool start = false;

            PriorityFilesSemaphore.WaitOne();
            IsPriorityRemaning = true;
            PriorityFilesSemaphore.Release();
            StartBackup("priority", priorityFiles, extensionsToEncrypt, logFiles, logfilesTocrypt, progress, start, Process);
            PriorityFilesSemaphore.WaitOne();
            IsPriorityRemaning = false;
            PriorityFilesSemaphore.Release();
            StartBackup("nonPriority", FilesToSave, extensionsToEncrypt, logFiles, logfilesTocrypt, progress, start, Process);

            while (logfilesTocrypt.Count > 0)
                start = CryptQueue(Process, logfilesTocrypt, logFiles, start, progress);

            //After all file's treatment
            //Update progress objet with end informations
            //And write it
            progress.State = "END";
            progress.WritingRealTimeLog();

            foreach (var log in logFiles)
                Log.WriteLog(log, xmlOrJsonLog);

            progress.Progression = 0;
            WriteProgressBar(progress);
        }
        //Private methods
        //
        private bool CryptQueue(Process Process, List<LogFile> logfilesTocrypt, List<LogFile> logFiles, bool start, RealTimeProgress progress)
        {
            if (start)
            {
                if (Process.HasExited && logfilesTocrypt != null && logfilesTocrypt.Count > 0) //Si le process est terminer 
                {
                    logfilesTocrypt.First().CryptingTime = Process.ExitCode; //recuperer la valeur de sortie et l'incorporée dans le premier objet LogFile correspondant
                    logFiles.Add(logfilesTocrypt.First());                 // Ajout de 'objet log dans la liste d'objet LogFile
                    logfilesTocrypt.Remove(logfilesTocrypt.First());      // Ensuite supprimer l'objet à crypter de la liste
                    progress.NbFilesLeftToDo--; //decrease number of files to do
                    progress.Progression = 100 - (progress.NbFilesLeftToDo * 100 / progress.TotalFileToCopy);
                    WriteProgressBar(progress);
                    if (logfilesTocrypt.Count != 0)
                    {
                        Process.StartInfo.Arguments = "\"" + logfilesTocrypt.First().FileSource + "\"" + " " + "\"" + logfilesTocrypt.First().FileTarget + "\"";  //passer en argument de process le source et target du prochain fichier à copier
                        Process.Start(); //Lancer le prochain processus
                    }
                    return true;
                }
                else
                    return true;
            }
            else if (!start && logfilesTocrypt != null && logfilesTocrypt.Count > 0)
            {
                Process.StartInfo.Arguments = "\"" + logfilesTocrypt.First().FileSource + "\"" + " " + "\"" + logfilesTocrypt.First().FileTarget + "\"";  //passer en argument de process le source et target du prochain fichier à copier
                Process.Start(); //Start next process
                return true;
            }
            else
                return false;
        }
        //If there are some subdirectories in the directory, this method extract files inside
        private void CreateSubDirectories(string filePath)
        {
            string fileName = filePath[(filePath.LastIndexOf('\\') + 1)..]; //Extract file name in the base target directory
            string subDir = filePath.Substring(0, filePath.Length - fileName.Length - 1);  // remove file name and keep all tree
            Directory.CreateDirectory(subDir); // create tree
        }
        private List<string> GetRunningBusinessSoftwares()    // A method which check if a business software is running
        {
            List<string> businessList = Settings.GetSettings().Business;
            List<string> businessRunning = new List<string>();

            foreach (string business in businessList)
            {
                Process[] proc = Process.GetProcessesByName(business);
                if (proc.Length > 0)
                    businessRunning.Add(business);
            }
            return businessRunning;     // return a list which contain the business softwares running
        }
        private List<Files> GetPriorityFiles()      // A method which check if priority files are in a backup work
        {
            List<string> priorityFileList = Settings.GetSettings().PriorityFiles;
            List<Files> priority = new List<Files>();

            foreach (var file in FilesToSave)
                if (priorityFileList.Contains(file.Extension))
                    priority.Add(file);

            foreach (var file in priority)
                    FilesToSave.Remove(file);

            return priority;  // return a list of priority files in a Backup work
        }
        private void GetAllFilesToBackup()
        {
            foreach (var file in Directory.GetFiles(Source, "*.*", SearchOption.AllDirectories))
            {
                FileInfo info = new FileInfo(file);
                FilesToSave.Add(new Files(info.Name, info.FullName, info.Extension, info.LastWriteTime, info.Length, info.Directory.ToString()));
            }
        }
        private void updateProgressBar(RealTimeProgress progress) { }
        private void StartBackup(string type, List<Files> fileList, List<string> extensionsToCrypt, List<LogFile> logfiles, List<LogFile> logfilesTocrypt, RealTimeProgress progress, bool start, Process process)
        {
            foreach (var srcFile in fileList)
            {
                while (!IsStatePlay && !Cancel)
                    Thread.Sleep(500);
                if (Cancel)
                    break;
                if (type == "nonPriority")
                {
                    bool check = true;
                    while (check)
                    {
                        PriorityFilesSemaphore.WaitOne();
                        if (!IsPriorityRemaning)
                            check = false;
                        PriorityFilesSemaphore.Release();
                    }
                }

                bool isBusiness = true; // treatment
                while (isBusiness)
                {
                    List<string> inUse = GetRunningBusinessSoftwares();
                    isBusiness = inUse.Count > 0;
                }
                string targetFilePath = Target + @"\" + srcFile.FullPath[(srcFile.FullPath.IndexOf(Source + @"") + Source.Length + 1)..];


                while (srcFile.FileSize > (Settings.GetSettings().InputFileSize * 1000))
                {
                    BigFileSemaphore.WaitOne();
                    if (BigFileState)
                    {
                        BigFileSemaphore.Release();
                    }
                    else
                    {
                        BigFileState = true;
                        BigFileSemaphore.Release();
                        break;
                    }
                }

                CreateSubDirectories(targetFilePath);

                if (extensionsToCrypt.Contains(srcFile.Extension))
                {
                    var log = new LogFile(Name, srcFile.FullPath, targetFilePath, Target, srcFile.FileSize, DateTime.Now.Millisecond, DateTime.Now);
                    logfilesTocrypt.Add(log);
                }
                else
                {
                    DateTime startcopyingtime = DateTime.Now; //Save start backup timestamp

                    if (Type == "Complete")
                        File.Copy(srcFile.FullPath, targetFilePath, true); //Copying file and overwrite if allready exist
                    else { try { File.Copy(srcFile.FullPath, targetFilePath, false); } catch (IOException) { } }

                    var endCopyingTime = DateTime.Now; //Save end backup timestamp

                    var log = new LogFile(Name, srcFile.FullPath, targetFilePath, Target, srcFile.FileSize, (endCopyingTime - startcopyingtime).TotalMilliseconds, DateTime.Now);
                    logfiles.Add(log);

                    progress.NbFilesLeftToDo--; //decrease number of files to do
                    progress.Progression = 100 - (progress.NbFilesLeftToDo * 100 / progress.TotalFileToCopy);
                    WriteProgressBar(progress);
                }
                //Write the progression file
                try
                { progress.WritingRealTimeLog(); }
                catch (InvalidOperationException) { throw; }
                
                start = CryptQueue(process, logfilesTocrypt, logfiles, start, progress);

                if (srcFile.FileSize > (Settings.GetSettings().InputFileSize * 1000))
                {
                    BigFileSemaphore.WaitOne();
                    BigFileState = false;
                    BigFileSemaphore.Release();                
                }
                
            }
            
            if (progress.TotalFileToCopy == 0)
            {
                progress.Progression = 100;
                WriteProgressBar(progress);
            }
        }
        private void WriteProgressBar(RealTimeProgress progress) => BackUpViewModel.GetBackUpViewModel().UpdateProgressBar(Name, Convert.ToInt32(progress.Progression));

    }
}

