using EasySaveApp_Client.View;
using EasySaveApp_Client.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Management;
using System.Threading;
using System.Windows.Controls;
using System.Windows;

namespace EasySaveApp_Client.Model
{
    public class Save
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public string Type { get; set; }

        // Contructor itinialise all Save attributes an scan for first time the Target Path
        public Save(string name, string source, string backupTarget, string type)
        {
            Name = name;
            Source = source;
            Target = backupTarget;
            Type = type;
        }

        private void WriteProgressBar()
        {

        }
    }
}

