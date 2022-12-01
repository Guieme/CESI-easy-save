using EasySaveApp.Model;
using EasySaveApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace EasySaveApp.Networking
{
    public static class ReceiveEvent
    {
        public static void ReceiveSomething()
        {
            while (Communication.client != null)
            {
                string data = Communication.ReceiveData();
                string name, source, target, type, content, pathType, path;
                MainViewModel MVM = MainViewModel.GetMainViewModel();

                switch (data)
                {
                    case "Initialisation":
                        BackupManagment.GetBackupManagment().SaveBackupList(MainViewModel.GetMainViewModel());
                        break;
                    case "Get backups":
                        SendBackups();
                        break;
                    case "Start_backup":
                        name = Communication.ReceiveData();
                        BackUpViewModel.GetBackUpViewModel().StartBackup(name, true);
                        Application.Current.Dispatcher.Invoke(() => { BackUpViewModel.GetBackUpViewModel().ActiveBackUp(name); });
                        break;

                    case "Start all backups":
                        BackUpViewModel.GetBackUpViewModel().StartAllBackup(true);
                        break;

                    case "Change backup's state":
                        content = Communication.ReceiveData();
                        name = content.Split(" ")[0];
                        type = content.Split(" ")[1];
                        BackUpViewModel.GetBackUpViewModel().ChangeState(name, type, true);
                        break;

                    case "Stop backup":
                        name = Communication.ReceiveData();
                        BackUpViewModel.GetBackUpViewModel().StopBackUp(name);
                        Application.Current.Dispatcher.Invoke(() => { BackUpViewModel.GetBackUpViewModel().StoppedBackup(name); });
                        break;

                    case "Add backup":
                        content = Communication.ReceiveData();
                        name = content.Split(" ")[0];
                        source = content.Split(" ")[1];
                        target = content.Split(" ")[2];
                        type = content.Split(" ")[3];
                        CreateBackUpViewModel.GetCreateBackUpViewModel().AddBackup(name, source, target, type);
                        break;

                    case "Edit backup type":
                        content = Communication.ReceiveData();
                        name = content.Split(" ")[0];
                        type = content.Split(" ")[1];
                        BackUpViewModel.GetBackUpViewModel().ChangeBackUpType(name, type);
                        break;

                    case "Edit backup path":
                        content = Communication.ReceiveData();
                        name = content.Split(" ")[0];
                        pathType = content.Split(" ")[1];
                        path = content.Split(" ")[2];
                        BackUpViewModel.GetBackUpViewModel().ChangePathSave(name, pathType, path);
                        break;

                    case "Delete backup":
                        name = Communication.ReceiveData();
                        BackUpViewModel.GetBackUpViewModel().DeleteBackup(name, true);
                        break;

                    case "Exit":
                        Communication.client.Close();
                        Communication.client = null;
                        break;

                    default:
                        break;
                }
            }
        }
        public static void SendBackups()
        {
            string response = null;
            List<Save> saves = BackUpViewModel.GetBackUpViewModel().GetSaveList();
            Communication.sendSemaphore.WaitOne();
            Communication.SendData("Get backups");
            Communication.sendSemaphore.Release();
            if (saves.Count == 0 || saves == null)
                response = "remove backups";
            else
            {
                foreach (Save save in saves)
                    response += save.Name + " " + save.Source + " " + save.Target + " " + save.Type + "!";
            }
            Communication.sendSemaphore.WaitOne();
            Communication.SendData(response);
            Communication.sendSemaphore.Release();
        }
    }
}
