using EasySaveApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace EasySaveApp.ViewModel
{
    internal class PriorityFilesViewModel
    {
        private static PriorityFilesViewModel Instance;
        private Settings settings;
        public static PriorityFilesViewModel GetPriorityFilesViewModel()
        {
            if (Instance == null)
                Instance = new PriorityFilesViewModel();
            return Instance;
        }
        private PriorityFilesViewModel() { settings = Settings.GetSettings(); }
        public List<string> GetPriorityFiles()
        {
            return settings.PriorityFiles;
        }

        public void AddPriorityFile(TextBox extension)
        {
            if (Input.VerifyExtensionToPrioriseExist(extension.Text) && Input.VerifyExtensionInput(extension.Text))
            {
                settings.PriorityFiles.Add(extension.Text);
                settings.WritePriorityFile();
                UserErrorManagement.InformationPopUp(Properties.Langs.Lang.Info_ExtensionAdded, extension.Text.ToString());
            }
            else if (!Input.VerifyExtensionToPrioriseExist(extension.Text))
            {
                UserErrorManagement.ErrorPopUp(Properties.Langs.Lang.Error_ExtensionToPriorise);
            }
            else
            {
                UserErrorManagement.ErrorPopUp(Properties.Langs.Lang.Error_ExtensionInvalidFormat);
            }
        }
        public void RemovePriorityFile(Button sender, StackPanel stackPanel)
        {
            if (UserErrorManagement.ChoicePopUp(Properties.Langs.Lang.ETCVM_Delete))
            {
                stackPanel.Children.Remove(GetCurrentSaveGrid(sender.Name.Substring(9), stackPanel));
                GetPriorityFiles().RemoveAt(GetPriorityFiles().IndexOf("." + sender.Name.Substring(9)));
                settings.WritePriorityFile();
            }
        }

        public void RemoveAllPriorityFile()
        {
            if (UserErrorManagement.ChoicePopUp(Properties.Langs.Lang.DeleteExtensionVerif))
            {
                settings.PriorityFiles.Clear();
                settings.WritePriorityFile();
            }
        }

        public void SortPriorityFile(Button button)
        {
            bool descending = false;
            if (button.Name == "descending")
                descending = true;
            settings.PriorityFiles.Sort();
            if (descending)
                settings.PriorityFiles.Reverse();
            settings.WritePriorityFile();
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
            if (stackPanel != null)
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

