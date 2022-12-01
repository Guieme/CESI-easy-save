using EasySaveApp_Client.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace EasySaveApp_Client.ViewModel
{
    internal class PriorityFilesViewModel
    {
        private static PriorityFilesViewModel Instance;
        public static PriorityFilesViewModel GetPriorityFilesViewModel()
        {
            if (Instance == null)
                Instance = new PriorityFilesViewModel();
            return Instance;
        }
        private PriorityFilesViewModel() {}
        public List<string> GetPriorityFiles()
        {
            return null;
        }

        public void AddPriorityFile(TextBox extension)
        {
        }
        public void RemovePriorityFile(Button sender, StackPanel stackPanel)
        {
        }
        public void SortPriorityFile(Button button)
        {
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

