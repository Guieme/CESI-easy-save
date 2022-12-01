using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;

namespace EasySaveApp.Model
{
    public class RealTimeProgress
    {
        //Info to put into the json file
        private static Semaphore IsWritingSemaphore = new Semaphore(1, 1);
        private string SaveName;
        private string SourcePath;
        private string TargetPath;
        public string State;
        public int TotalFileToCopy;
        private float TotalFileSize;
        public int NbFilesLeftToDo;
        public float Progression;
        private string JsonFilePath = BackupManagment.Location + $@"\RealTimeLog\RealTimeLog.json"; //Path where you want your json file to be

        //Class Constructor
        public RealTimeProgress(string saveNameIn, string sourcePathIn, string targetPathIn, string stateIn, int totalFileToCopyIn, float totalFileSizeIn, int nbFilesLeftToDoIn, float progressionIn)
        {
            SaveName = saveNameIn;
            SourcePath = sourcePathIn;
            TargetPath = targetPathIn;
            State = stateIn;
            TotalFileToCopy = totalFileToCopyIn;
            TotalFileSize = totalFileSizeIn;
            NbFilesLeftToDo = nbFilesLeftToDoIn;
            Progression = progressionIn;
        }
        //LineChanger function is use to update a specified line into a file
        public void LineChanger(string newText, string fileName, int lineToEdit)
        {
            // Exception is trigerred if the file is empty, cannot get the index of the line to edit
            try
            {
                string[] arrLine = File.ReadAllLines(fileName); //Array of jsonfile's text line
                arrLine[lineToEdit - 1] = newText;              //Text index starts at 1, array index starts at 0
                File.WriteAllLines(fileName, arrLine);          // Write text on the specified lines
            }
            catch (IndexOutOfRangeException)
            {
                // If catch, no file found or the jsonfile is empty
                File.WriteAllText(fileName, "[ \n   {");        //Initalize the jsonfile
                string[] arrLine = File.ReadAllLines(fileName); 
                arrLine[lineToEdit - 1] = newText;
                File.WriteAllLines(fileName, arrLine);
            }
        }

        //AlreadyExists check into the json file if the save entered is already present into the specified file
        public int AlreadyExists(string path, string saveNameToIdentify)
        {
            var nbLines = File.ReadAllLines(path).Length; //nbLines counts the number of lines into the jsonfile
            StreamReader reader = new StreamReader(path); //Open a StreamReader to read the jsonfile
            try
            {
                string lineContent = (string)File.ReadAllLines(path).GetValue(2);       //Get the line 3's content as a string
                string toVerify = "       \"Name\": \"" + saveNameToIdentify + "\",";   //toVerify set the string to recognize into the jsonfile
                if (lineContent.Equals(toVerify))           //try to match linecontent with the string toVerify
                {
                    reader.Close(); //Close the StreamReader
                    return 3;       //Return the line number
                }
                else
                {
                    int i = 14;     // i is the line number where the save name is
                    int para = 1;   // para Counts the block of parameters
                    while (i < nbLines) //While there's a line number where a save name can be found, continue to parse the jsonfile
                    {
                        lineContent = (string)File.ReadAllLines(path).GetValue(2 + 11 * para);  //Get the content of the line as a string
                        if (lineContent.Contains(toVerify))                                     //try to match linecontent with the string toVerify
                        {
                            int line = +3 + 11 * para;  //increase the line number to refer to tghe next block
                            reader.Close();             //Close the StreamReader
                            return line;                //Return the line number
                        }
                        i = +11; //increase i to match with the next savename line
                        para++;  //Refer to the next block
                    }
                }
                reader.Close(); //Close the StreamReader
            }
            catch (System.IndexOutOfRangeException) //Exception trigerred if the jsonfile is empty or line 3 empty
            {
                reader.Close(); //Close the StreamReader
                return 0;       //Return no line number
            }
            reader.Close();     //Close the StreamReader
            return 0;           //Return no line number
        }

        public void WritingRealTimeLog()
        {
            IsWritingSemaphore.WaitOne();
            // Write down first "[" into the file RealTimeLog.json on line 1.
            LineChanger("[", JsonFilePath, 1);

            //Get the Time
            DateTime thisDay = DateTime.Now;
            //Convert it to string
            string thisDayTime = thisDay.ToString();
            //Check if the save name already exists
            int lineToChange = AlreadyExists(JsonFilePath, SaveName);

            if (lineToChange == 0) //No match found
            {
                var nbLines = File.ReadAllLines(JsonFilePath).Length;   //Count lines
                LineChanger("", JsonFilePath, nbLines);                 //Delete the last line form the jsonfile file

                if (nbLines > 1)
                {
                    LineChanger("   },", JsonFilePath, nbLines - 1);    //Set line 2 "  }"
                }

                if (State == "ACTIVE")  //ACTIVE save
                {
                    // Store the info into a string array
                    string[] saveInfo =
                    {
                    "       \"Name\": \"" + SaveName + "\",\n",
                    "       \"ActiveTime\": \"" + thisDayTime + "\",\n",
                    "       \"SourceFilePath\":\"" + SourcePath + "\",\n",
                    "       \"TargetFilePath\":\"" + TargetPath + "\",\n",
                    "       \"State\":\"" + State + "\",\n",
                    "       \"TotalFilesToCopy\": " + TotalFileToCopy +",\n",
                    "       \"TotalFilesSize\": " + TotalFileSize +",\n",
                    "       \"NbFilesLeftToDo\": " + NbFilesLeftToDo + ",\n",
                    "       \"Progression\": " + Progression
                    };

                    LineChanger("   {", JsonFilePath, nbLines);     //Open bracket for the block
                    foreach (string info in saveInfo)               //Write down the info line by line
                    {
                        File.AppendAllText(JsonFilePath, info);
                    }
                    File.AppendAllText(JsonFilePath, "\n" + "   }");//Close bracket for the block
                    File.AppendAllText(JsonFilePath, "\n" + "]");   //Cloe the jsonfile by ending it with a ]
                }
                else if (State == "END") //ENDED save (same process as ACTIVE)
                {
                    string[] saveInfo =
                    {
                    "       \"Name\": \"" + SaveName + "\",\n",
                    "       \"ActiveTime\": \"" + thisDayTime + "\",\n",
                    "       \"SourceFilePath\":\"\",\n",
                    "       \"TargetFilePath\":\"\",\n",
                    "       \"State\":\"" + State + "\",\n",
                    "       \"TotalFilesToCopy\": 0,\n",
                    "       \"TotalFilesSize\": 0,\n",
                    "       \"NbFilesLeftToDo\": 0,\n",
                    "       \"Progression\": 0"
                    };

                    LineChanger("   {", JsonFilePath, nbLines);
                    foreach (string info in saveInfo)
                    {
                        File.AppendAllText(JsonFilePath, info);
                    }
                    File.AppendAllText(JsonFilePath, "\n" + "   }");
                    File.AppendAllText(JsonFilePath, "\n" + "]");
                }
            }
            else
            {
                // if the savename already exists in the jsonfile
                if (State == "ACTIVE")
                {
                   
                    LineChanger("       \"Name\": \"" + SaveName + "\",", JsonFilePath, lineToChange);
                    LineChanger("       \"ActiveTime\": \"" + thisDayTime + "\",", JsonFilePath, lineToChange + 1);
                    LineChanger("       \"SourceFilePath\":\"" + SourcePath + "\",", JsonFilePath, lineToChange + 2);
                    LineChanger("       \"TargetFilePath\":\"" + TargetPath + "\",", JsonFilePath, lineToChange + 3);
                    LineChanger("       \"State\":\"" + State + "\",", JsonFilePath, lineToChange + 4);
                    LineChanger("       \"TotalFilesToCopy\": " + TotalFileToCopy + ",", JsonFilePath, lineToChange + 5);
                    LineChanger("       \"TotalFilesSize\": " + TotalFileSize + ",", JsonFilePath, lineToChange + 6);
                    LineChanger("       \"NbFilesLeftToDo\": " + NbFilesLeftToDo + ",", JsonFilePath, lineToChange + 7);
                    LineChanger("       \"Progression\": " + Progression + "", JsonFilePath, lineToChange + 8);
                }
                else if (State == "END")
                {
                    //Change the content line with another content
                    LineChanger("       \"Name\": \"" + SaveName + "\",", JsonFilePath, lineToChange);
                    LineChanger("       \"ActiveTime\": \"" + thisDayTime + "\",", JsonFilePath, lineToChange + 1);
                    LineChanger("       \"SourceFilePath\":\"\",", JsonFilePath, lineToChange + 2);
                    LineChanger("       \"TargetFilePath\":\"\",", JsonFilePath, lineToChange + 3);
                    LineChanger("       \"State\":\"" + State + "\",", JsonFilePath, lineToChange + 4);
                    LineChanger("       \"TotalFilesToCopy\": 0,", JsonFilePath, lineToChange + 5);
                    LineChanger("       \"TotalFilesSize\": 0,", JsonFilePath, lineToChange + 6);
                    LineChanger("       \"NbFilesLeftToDo\": 0,", JsonFilePath, lineToChange + 7);
                    LineChanger("       \"Progression\": 0", JsonFilePath, lineToChange + 8);
                }
            }
            IsWritingSemaphore.Release();
        }
    }
}
