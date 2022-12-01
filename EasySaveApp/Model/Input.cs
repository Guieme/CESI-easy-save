using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EasySaveApp.ViewModel;

namespace EasySaveApp.Model
{
    public class Input
    {
        //IsDir permit to check is the parameter passed in the method is a existing path or not
        //If yes, return true, else return false
        static public bool IsDir(string path)
        {
            try
            {
                FileAttributes attr;
                attr = File.GetAttributes(path);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //VerifyPath check if we can write in path speficied in parameter or not
        //If yes, return true, else return false
        static public bool VerifyPath(string path, int type)
        {
            if (IsDir(path))
            {
                try
                {
                    var tmp = path + @$"\.{DateTime.Now.GetHashCode()}.temp";
                    var f = File.Create(tmp);
                    f.Dispose();
                    File.Delete(tmp);
                    return true;
                }
                catch (UnauthorizedAccessException)
                {
                    /// Menu.GetMenu().HandleExceptions(ex.Message);
                    return false;
                }
            }
            //else if (type == 1)
            //{
            //    try
            //    {
            //        Directory.CreateDirectory(path);
            //        return true;
            //    }
            //    catch (UnauthorizedAccessException)
            //    {
            //        return false;
            //    }
            //    catch (ArgumentException)
            //    {
            //        return false;
            //    }
            //}
            else
                return false;
        }

        //VerifySave check if the save who will be created already exist or not
        //If yes, return false, else return true
        static public bool VerifySave(string saveName)
        {
            bool test = true;
            if (MainViewModel.GetMainViewModel().saves != null && MainViewModel.GetMainViewModel().saves.Count != 0)
            {
                foreach (var actualSave in MainViewModel.GetMainViewModel().saves)
                {
                    if (actualSave.Name == saveName)
                        test = false;
                }
            }
            else
            {
                test = true;
            }
            return test;
        }
        //NotSamePath check if the source path and the target are sames
        //If yes, return false, else return true
        static public bool NotSamePath(string source, string target)
        {
            bool test = true;
            if(source == target)
            {
                test = false;
            }
            return test;
        }
        //VerifyExtensionExist check if the file have to be encryted on copy or not
        //If yes, return false, else return true
        static public bool VerifyExtensionExist(string extension)
        {
            bool test = true;
            if (Settings.GetSettings().ExtensionsToCrypt != null && Settings.GetSettings().ExtensionsToCrypt.Count !=0)
            {
                foreach (var actualExtension in Settings.GetSettings().ExtensionsToCrypt)
                {
                    if (actualExtension == extension)
                        test = false;
                }
            }
            else
            {
                test = true;
            }
            return test;
        }
        //VerifyExtensionToPrioriseExist check if the file have to be priorise on copy or not
        //If yes, return false, else return true
        static public bool VerifyExtensionToPrioriseExist(string extension)
        {
            bool test = true;
            if (Settings.GetSettings().PriorityFiles != null && Settings.GetSettings().PriorityFiles.Count != 0)
            {
                foreach (var actualExtension in Settings.GetSettings().PriorityFiles)
                {
                    if (actualExtension == extension)
                        test = false;
                }
            }
            else
            {
                test = true;
            }
            return test;
        }

        //VerifyExtensionInput check if the specified extension respect standard or not
        //If yes, return false, else return true
        static public bool VerifyExtensionInput(string extension)
        { 
            if(extension !="" && extension.Substring(0, 1) == ".")
            {
               return true;
            }
            else
            {
                return false;
            }
        }

        //VerifyBusinessExist check if the software already exist or not
        //If yes return true, else return false
        static public bool VerifyBusinessExist(string business)
        {
            bool result = true;
            if (Settings.GetSettings().Business != null && Settings.GetSettings().Business.Count != 0)
            {
                foreach (var actualBusiness in Settings.GetSettings().Business)
                {
                    if (actualBusiness == business)
                        result = false;
                }
            }
            else
            {
                result = true;
            }
            return result;
        }
    }
}
