using EasySaveApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using EasySaveApp.Properties.Langs;
using System.Diagnostics;

namespace EasySaveApp.ViewModel
{
    class InputFileSizeViewModel
    {
        private static InputFileSizeViewModel Instance;
        private Settings settings;

        public static InputFileSizeViewModel GetInputFileSizeViewModel()
        {
            if (Instance == null)
                Instance = new InputFileSizeViewModel();
            return Instance;
        }
        private InputFileSizeViewModel() { settings = Settings.GetSettings(); }
        
        public void ConfirmSave(string fileSize) //Add new max size file
        {
            if(fileSize == "")  //if entry is null
            {
                UserErrorManagement.ErrorPopUp(Lang.VIFS_ErrorEmpty); //Show Error
            }
            else                //if entry as a correct value
            {
                if (UserErrorManagement.ChoicePopUp(Lang.VIFS_AddConfirmation)) //Ask user if he wants to change the value or not
                {
                    UserErrorManagement.InformationPopUp(Lang.VIFS_Confirm, fileSize);       //Show popUp confirmation
                    Settings.GetSettings().InputFileSize = Convert.ToInt64(fileSize);       //Convert input into 64 base
                    settings.WriteInputFileSize();                                          //Add it
                }
                else
                {
                    //do nothing
                }
            }
        }

        internal void InitView(TextBox fileSize)
        {
            if (settings.InputFileSize > 0)
                fileSize.Text = settings.InputFileSize.ToString();
        }
    }
}
