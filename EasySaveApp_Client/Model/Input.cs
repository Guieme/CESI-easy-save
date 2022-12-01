using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EasySaveApp_Client.ViewModel;

namespace EasySaveApp_Client.Model
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
                    return false;
                }
            }
            else
                return false;
        }

        //VerifySave check if the save who will be created already exist or not
        //If yes, return false, else return true
        static public bool VerifySave(string saveName)
        {
            bool test = true;
            if (BackUpViewModel.GetBackUpViewModel().GetSaves() != null && BackUpViewModel.GetBackUpViewModel().GetSaves().Count != 0)
            {
                foreach (var actualSave in BackUpViewModel.GetBackUpViewModel().GetSaves())
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
    }
}
