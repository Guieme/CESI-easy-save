using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using EasySaveApp.Model;

namespace EasySaveApp.ViewModel
{
    internal class BusinessSoftwareViewModel
    {

        private static BusinessSoftwareViewModel Instance;
        private Settings settings;
        public static BusinessSoftwareViewModel GetBusinessSoftwareViewModel()
        {
            if (Instance == null)
                Instance = new BusinessSoftwareViewModel();
            return Instance;
        }
        private BusinessSoftwareViewModel() { settings = Settings.GetSettings(); }

        public List<string> GetBusiness() => settings.Business;

        public void ChangeBusiness(List<string> business)
        {
            settings.Business = business;
            settings.WriteBusinessFile();
        }

        public void AddBusinessSoftWare(TextBox BusinessSoftWare)
        {
            if (BusinessSoftWare.Text.Contains("."))
            {
                string BusinessSoft = BusinessSoftWare.Text;
                string Business = BusinessSoft.Substring(0, BusinessSoft.IndexOf("."));
                if (Input.VerifyBusinessExist(Business))
                {
                    settings.Business.Add(Business);
                    settings.WriteBusinessFile();
                    UserErrorManagement.InformationPopUp(Properties.Langs.Lang.Info_SoftwareAdded, Business);
                }
                else
                {
                    UserErrorManagement.ErrorPopUp(Properties.Langs.Lang.Error_BusinessSoftware);
                }
            }
            else if (BusinessSoftWare.Text=="")
            {
                UserErrorManagement.ErrorPopUp(Properties.Langs.Lang.Error_BusinessInvalidFormat);
            }
            else
            {
                if (Input.VerifyBusinessExist(BusinessSoftWare.Text))
                {
                    settings.Business.Add(BusinessSoftWare.Text);
                    settings.WriteBusinessFile();
                    UserErrorManagement.InformationPopUp(Properties.Langs.Lang.Info_SoftwareAdded, BusinessSoftWare.Text.ToString());
                }
                else
                {
                    UserErrorManagement.ErrorPopUp(Properties.Langs.Lang.Error_BusinessSoftware);
                }
            }

        }
        public void RemoveBusinessSoftWare(Button sender, StackPanel stackPanel)
        {
            if (UserErrorManagement.ChoicePopUp(Properties.Langs.Lang.BSVM_Delete))
            {
                stackPanel.Children.Remove(GetCurrentSaveGrid(sender.Name.Substring(9), stackPanel));
                GetBusiness().RemoveAt(GetBusiness().IndexOf(sender.Name.Substring(9).Replace("_", ".")));
                settings.WriteBusinessFile();
            }
        }

        public void RemoveAllBusiness()
        {
            if (UserErrorManagement.ChoicePopUp(Properties.Langs.Lang.DeleteExtensionVerif))
            {
                settings.Business.Clear();
                settings.WriteBusinessFile();
            }
        }

        public void SortBusinessSoftWareList(Button button)
        {
            bool descending = false;
            if (button.Name == "descending")
                descending = true;
            settings.Business.Sort();
            if (descending)
                settings.Business.Reverse();
            settings.WriteBusinessFile();
        }
        private GroupItem GetCurrentSaveGrid(string saveName, StackPanel BusinessSoftWareList)
        {
            GroupItem groupItem = null;
            foreach (var child in BusinessSoftWareList.Children)
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
