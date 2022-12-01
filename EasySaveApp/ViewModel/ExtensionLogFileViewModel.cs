using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using EasySaveApp.Model;

namespace EasySaveApp.ViewModel
{
    internal class ExtensionLogFileViewModel
    {
        private static ExtensionLogFileViewModel Instance;
        public static ExtensionLogFileViewModel GetExtensionLogFileViewModel()
        {
            if (Instance == null)
                Instance = new ExtensionLogFileViewModel();
            return Instance;
        }
        private Settings settings;
        private ExtensionLogFileViewModel() { settings = Settings.GetSettings(); }

        private bool GetExtiensionLog() => settings.xmlLogs;
        private void SetExtensionLog(bool extension) => settings.xmlLogs = extension;

        public void InitViewButtons(RadioButton xml, RadioButton json)
        {
            if (GetExtiensionLog())
                xml.IsChecked = true;
            else if (!GetExtiensionLog())
                json.IsChecked = true;
        }
        public void CheckedExtension(Image xml, Image json, RadioButton source)
        {
            if (source.Name == "JsonRadioButton")
            {
                json.Source = new BitmapImage(new Uri(@"\Images\FrameWrokPlain.png", UriKind.Relative));
                xml.Source = new BitmapImage(new Uri("\\Images\\FrameWrok.png", UriKind.Relative));
            }
            else if (source.Name == "XmlRadioButton")
            {
                json.Source = new BitmapImage(new Uri("\\Images\\FrameWrok.png", UriKind.Relative));
                xml.Source = new BitmapImage(new Uri(@"\Images\FrameWrokPlain.png", UriKind.Relative));
            }
        }
        public void ConfirmExtensionLogFile(RadioButton xml, RadioButton json)
        {
            if (json.IsChecked.Value)
            {
                SetExtensionLog(false);
                UserErrorManagement.InformationPopUp(Properties.Langs.Lang.Info_LogExtension, "json");
            }
            else if (xml.IsChecked.Value)
            {
                SetExtensionLog(true);
                UserErrorManagement.InformationPopUp(Properties.Langs.Lang.Info_LogExtension, "xml");
            }
        }
    }
}
