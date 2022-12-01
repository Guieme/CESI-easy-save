using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace EasySaveApp.ViewModel
{
    static class UserErrorManagement
    {
        public static void ErrorPopUp(string mssg) // PopUp that appears when an user error occure. The error message is translated and taken into the function parameter.
        {
            MessageBox.Show(mssg, Properties.Langs.Lang.Error, MessageBoxButton.OK, MessageBoxImage.Error); //Show the PopUp window with the speciefied error message, an OK button and an error Image "X".
        }

        public static void InformationPopUp(string mssg, string extramassg = "", bool nostart = false) //Show an information PopUp / Options : Add an extra message placed at the beginning or after the first ":" of string message
        {
            int parse = mssg.Length - 1; // amount of caaracters to parse into the string
            if(extramassg == "")         // if no extra message 
            {
                MessageBox.Show(mssg, Properties.Langs.Lang.Info, MessageBoxButton.OK, MessageBoxImage.Information); // No extra message → show basic Information PopUp
            }
            else if (nostart)           // if no start is true
            {
                string burger2 = mssg.Substring(mssg.IndexOf(":", 0, parse) + 2, mssg.Length - mssg.IndexOf(":", 0, parse) - 2); // split the string at ":" index, conserve right part
                string infomssg = extramassg + " " + burger2;                                                                    // Create the new string
                MessageBox.Show(infomssg, Properties.Langs.Lang.Info, MessageBoxButton.OK, MessageBoxImage.Information);         // Personnalized info popup : info + txt
            }
            else
            {
                string burger1 = mssg.Substring(0, mssg.IndexOf(":", 0, parse)+1);                                               // split the string at ":" index, conserve left part
                string burger2 = mssg.Substring(mssg.IndexOf(":", 0, parse)+2, mssg.Length - mssg.IndexOf(":", 0, parse) - 2);   // split the string at ":" index, conserve right part
                string infomssg = burger1 + " " + extramassg + " " + burger2;                                                    // Create the new string
                MessageBox.Show(infomssg, Properties.Langs.Lang.Info, MessageBoxButton.OK, MessageBoxImage.Information);         // Personnalized info popup : txt + info + txt
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
