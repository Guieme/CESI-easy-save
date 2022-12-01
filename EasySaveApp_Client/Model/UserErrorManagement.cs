using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace EasySaveApp_Client.ViewModel
{
    static class UserErrorManagement
    {
        public static void ErrorPopUp(string mssg) // PopUp that appears when an user error occure. The error message is translated and taken into the function parameter.
        {
            MessageBox.Show(mssg, Properties.Langs.Lang.Error, MessageBoxButton.OK, MessageBoxImage.Error); //Show the PopUp window with the speciefied error message, an OK button and an error Image "X".
        }

        public static void InformationPopUp(string mssg, string extramassg = "", bool nostart = false)
        {
            if(extramassg == "")
            {
                MessageBox.Show(mssg, Properties.Langs.Lang.Info, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (nostart)
            {
                string burger2 = mssg.Substring(mssg.IndexOf(":", 0, 50) + 2, mssg.Length - mssg.IndexOf(":", 0, 50) - 2);
                string infomssg = extramassg + " " + burger2;
                MessageBox.Show(infomssg, Properties.Langs.Lang.Info, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int sauce = mssg.IndexOf(":", 0, 50);
                string burger1 = mssg.Substring(0, mssg.IndexOf(":", 0, 50)+1);
                string burger2 = mssg.Substring(mssg.IndexOf(":", 0, 50)+2, mssg.Length - mssg.IndexOf(":", 0, 50) - 2);
                string infomssg = burger1 + " " + extramassg + " " + burger2;
                MessageBox.Show(infomssg, Properties.Langs.Lang.Info, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public static bool ChoicePopUp(string mssg) //PopUp that appears when user has a choice to do. The choice message is translated and user can either choose between YES or NO.
        {
            MessageBoxResult result =  MessageBox.Show(mssg, Properties.Langs.Lang.Choice, MessageBoxButton.YesNo, MessageBoxImage.Warning); //Show the PopUp window with specified message choice, both buttons "YES" and "NO" and a warning image

           if(result==MessageBoxResult.Yes) //Check the user choice ("YES" or "NO" checked)
            {
                return true; //if "YES" checked
            }
           else
            {
                return false; //if "NO" checked
            }
        }
    }
}
