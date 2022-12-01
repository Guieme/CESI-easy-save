using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using EasySaveApp.Model;

namespace EasySaveApp.ViewModel
{
    internal class ExtensionToCryptViewModel
    {
        private static ExtensionToCryptViewModel Instance;
        private Settings settings;
        public static ExtensionToCryptViewModel GetExtensionToCryptViewModel()
        {
            if (Instance == null)
                Instance = new ExtensionToCryptViewModel();
            return Instance;
        }
        private ExtensionToCryptViewModel() { settings = Settings.GetSettings(); }

        public void ChangeExtensionToCrypt(List<string> extensions)
        {
            settings.ExtensionsToCrypt = extensions;
            settings.WriteExtensionFile();
        }
        public List<string> GetExtensionsToEncrypt()
        {
            return settings.ExtensionsToCrypt;
        }

        public void AddExtension(TextBox extension)
        {  
            if (Input.VerifyExtensionExist(extension.Text) && Input.VerifyExtensionInput(extension.Text))
            {
                settings.ExtensionsToCrypt.Add(extension.Text);
                settings.WriteExtensionFile();
                UserErrorManagement.InformationPopUp(Properties.Langs.Lang.Info_ExtensionAdded, extension.Text);
            }
            else if (!Input.VerifyExtensionExist(extension.Text))
            {
                UserErrorManagement.ErrorPopUp(Properties.Langs.Lang.Error_ExtensionToCrypt);
            }
            else
            {
                UserErrorManagement.ErrorPopUp(Properties.Langs.Lang.Error_ExtensionInvalidFormat);
            }
        }
        public void RemoveExtension(Button sender, StackPanel stackPanel)
        {
            if (UserErrorManagement.ChoicePopUp(Properties.Langs.Lang.ETCVM_Delete))
            {
                stackPanel.Children.Remove(GetCurrentSaveGrid(sender.Name.Substring(9), stackPanel));
                GetExtensionsToEncrypt().RemoveAt(GetExtensionsToEncrypt().IndexOf("." + sender.Name.Substring(9)));
                settings.WriteExtensionFile();
            }
        }

        public void RemoveAllExtension()
        {
            if (UserErrorManagement.ChoicePopUp(Properties.Langs.Lang.DeleteExtensionVerif))
            {
                settings.ExtensionsToCrypt.Clear();
                settings.WriteExtensionFile();
            }
        }

        public void SortExtensionList(Button button)
        {
            bool descending = false;
            if (button.Name == "descending")
                descending = true;
            settings.ExtensionsToCrypt.Sort();
            if (descending)
                settings.ExtensionsToCrypt.Reverse();
            settings.WriteExtensionFile();
        }
        private GroupItem GetCurrentSaveGrid(string saveName, StackPanel extensionList)
        {
            GroupItem groupItem = null;
            foreach (var child in extensionList.Children)
            {
                GroupItem groupitem = (GroupItem)child;
                if (groupitem.Name == saveName)
                    groupItem = groupitem;
                else
                    continue;
            }
            return groupItem;
        }
        public void DynamicSearch(string textSearch, StackPanel stackPanel)
        {
            if(stackPanel != null)
            {
                List<GroupItem> ToRemove = new List<GroupItem>();
                foreach (var child in stackPanel.Children)
                {
                    GroupItem groupitem = (GroupItem)child;
                    if (textSearch != null && !groupitem.Name.Contains(textSearch))
                        ToRemove.Add(groupitem); 
                    else
                        groupitem.Visibility = System.Windows.Visibility.Visible;
                }
                foreach (var groupItem in ToRemove)
                {
                    stackPanel.Children.Remove(groupItem);
                }
            }
        }
    }
}
