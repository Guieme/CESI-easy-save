using EasySaveApp_Client.Model;
using EasySaveApp_Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;

namespace EasySaveApp_Client.Networking
{
    public static class ReceiveEvent
    {
        public static void ReceiveSomething()
        {
            while (true)
            {
                string data = Communication.ReceiveData();
                string name, value, content, type;
                MainViewModel MVM = MainViewModel.GetMainViewModel();

                switch (data)
                {
                    case "Start_backup":
                        name = Communication.ReceiveData();
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
                        Application.Current.Dispatcher.Invoke(() => { BackUpViewModel.GetBackUpViewModel().StoppedBackup(name); });
                        break;
                    case "Get backups":
                        Application.Current.Dispatcher.Invoke(() => { BackUpViewModel.GetBackUpViewModel().SetSaves(GetBackups()); });
                        break;
                    case "Get progress":
                        content = Communication.ReceiveData();
                        name = content.Split(" ")[0];
                        value = content.Split(" ")[1];
                        BackUpViewModel.GetBackUpViewModel().UpdateProgressBar(name, Convert.ToInt32(value));
                        break;
                    case "Exit":
                        UserErrorManagement.ErrorPopUp("Server has close the connection");
                        Communication.server.Close();
                        Communication.server = null;
                        Process.GetCurrentProcess().Kill();
                        break;
                    default:
                        break;
                }
            }
        }
        private static List<Save> GetBackups()
        {
            List<Save> saves = new List<Save>();

            string data = Communication.ReceiveData();
            data = data.Substring(0, data.Length -1);
            if (data == "remove backup")
                saves.Clear();
            else
            {
                foreach (string s in data.Split("!"))
                {
                    Save actualsave = new Save(s.Split(' ')[0], s.Split(' ')[1], s.Split(' ')[2], s.Split(' ')[3]);
                    saves.Add(actualsave);
                }
            }
            return saves;
        }
    }
}
