using System;
using Xunit;
using EasySaveApp.Model;
using System.IO;
using System.Collections.Generic;
using EasySaveApp.View;
using System.Diagnostics;
using System.Linq;




namespace EasySaveTests.Model
{
    [Collection("Sequential")]
    public class SaveTests
    {
        [Fact]
        public void Step03_StartSaveTest()
        {
            var disp = DisplayMenu.GetView();
            var baseDir = @"C:\Users\Public\Saves";
            if (Directory.Exists(baseDir))
            {
                Directory.Delete(baseDir, true);
            }
            var scr = "DirSrc";
            var tar = "DirTarget";

            Directory.CreateDirectory($@"{baseDir}\{scr}\SubDir");
            Directory.CreateDirectory($@"{baseDir}\{tar}");

            var file1 = File.Create($@"{baseDir}\{scr}\testFile.txt");
            var file2 = File.Create($@"{baseDir}\{scr}\SubDir\testFile.txt");

            file1.Close();
            file2.Close();

            var save1 = new Save($@"{baseDir}\DirTarget", $@"{baseDir}\DirSrc", "save1", "Complete");
            var save2 = new Save($@"{baseDir}\DirTarget", $@"{baseDir}\DirSrc", "save1", "Differential");

            save1.StartSave("en", disp, false);
            File.Delete(@"\\logs" + DateTime.Now.ToString("ddMMyyyy") + "_log.json");

            Assert.True(File.Exists($@"{baseDir}\{tar}\testFile.txt"));
            Assert.True(File.Exists($@"{baseDir}\{tar}\SubDir\testFile.txt"));

            File.WriteAllTextAsync(file1.Name, "sample test");
            
            save2.StartSave("en", disp, false);
            File.Delete(@"\\logs" + DateTime.Now.ToString("ddMMyyyy") + "_log.json");

            Assert.Equal(File.GetLastWriteTime(file1.Name), File.GetLastWriteTime($@"{baseDir}\{tar}\testFile.txt"));

            Directory.Delete(baseDir, true);
        }

        [Fact]
        public void Step00_InitializeFilesToBackupInConstructor()   //This method will test if the initialization of SelectFilesToBackup attribute is correct when a Save object is create
        {
            var baseDir = @"\\SelectFilesToBackup_TEST";
            if (Directory.Exists(baseDir))
            {
                Directory.Delete(baseDir, true);
            }
            var scr = "DirSource";
            var tar = "DirTarget";

            Directory.CreateDirectory($@"{baseDir}\{scr}\SubDir");
            Directory.CreateDirectory($@"{baseDir}\{tar}\SubDir");

            var file1 = File.Create($@"{baseDir}\{scr}\need to update 1.txt");
            var file2 = File.Create($@"{baseDir}\{scr}\need to update 3.txt");
            var file3 = File.Create($@"{baseDir}\{scr}\Pas save 1.txt");
            var file4 = File.Create($@"{baseDir}\{scr}\Save 2.txt");
            var file5 = File.Create($@"{baseDir}\{scr}\Save 3.txt");
            var file6 = File.Create($@"{baseDir}\{scr}\SubDir\need to update 2.txt");
            var file7 = File.Create($@"{baseDir}\{scr}\SubDir\Pas save 2.txt");
            var file8 = File.Create($@"{baseDir}\{scr}\SubDir\Pas save 3.txt");
            var file9 = File.Create($@"{baseDir}\{scr}\SubDir\Save 1.txt");

            file1.Close();
            file2.Close();
            file3.Close();
            file4.Close();
            file5.Close();
            file6.Close();
            file7.Close();
            file8.Close();
            file9.Close();

            File.WriteAllTextAsync(file3.Name, "sample test");
            File.WriteAllTextAsync(file4.Name, "sample test");
            File.WriteAllTextAsync(file5.Name, "sample test");
            File.WriteAllTextAsync(file7.Name, "sample test");
            File.WriteAllTextAsync(file8.Name, "sample test");
            File.WriteAllTextAsync(file9.Name, "sample test");

            File.Copy($@"{baseDir}\{scr}\need to update 1.txt", $@"{baseDir}\{tar}\need to update 1.txt", true);
            File.Copy($@"{baseDir}\{scr}\SubDir\need to update 2.txt", $@"{baseDir}\{tar}\need to update 2.txt", true);
            File.Copy($@"{baseDir}\{scr}\SubDir\Save 1.txt", $@"{baseDir}\{tar}\Save 1.txt", true);
            File.Copy($@"{baseDir}\{scr}\Save 2.txt", $@"{baseDir}\{tar}\Save 2.txt", true);
            File.Copy($@"{baseDir}\{scr}\need to update 3.txt", $@"{baseDir}\{tar}\SubDir\need to update 3.txt", true);
            File.Copy($@"{baseDir}\{scr}\Save 3.txt", $@"{baseDir}\{tar}\SubDir\Save 3.txt", true);

            File.WriteAllTextAsync(file1.Name, "sample test");
            File.WriteAllTextAsync(file2.Name, "sample test");
            File.WriteAllTextAsync(file6.Name, "sample test");

            file1.Close();
            file2.Close();
            file3.Close();
            file4.Close();
            file5.Close();
            file6.Close();
            file7.Close();
            file8.Close();
            file9.Close();
           
            Save Save1 = new Save($@"{baseDir}\{tar}", $@"{baseDir}\{scr}", "Save1", "Complete");     // Creation of an object Save
            Save Save2 = new Save($@"{baseDir}\{tar}", $@"{baseDir}\{scr}", "Save2", "Differential");
            Save Save3 = new Save($@"{baseDir}\{tar}", $@"{baseDir}\{scr}\SubDir\", "Save3", "Complete");
            Save Save4 = new Save($@"{baseDir}\{tar}", $@"{baseDir}\{scr}\SubDir\", "Save4", "Differential");
            Save Save5 = new Save($@"{baseDir}\{tar}\SubDir\", $@"{baseDir}\{scr}", "Save5", "Complete");
            Save Save6 = new Save($@"{baseDir}\{tar}\SubDir\", $@"{baseDir}\{scr}", "Save6", "Differential");
            Save Save7 = new Save($@"{baseDir}\{tar}", $@"{baseDir}\{scr}\Save 2.txt", "Save7", "Complete");
            Save Save8 = new Save($@"{baseDir}\{tar}", $@"{baseDir}\{scr}\Save 2.txt", "Save8", "Differential");
            Save Save9 = new Save($@"{baseDir}\{tar}", $@"{baseDir}\{scr}\SubDir\Pas save 2.txt", "Save9", "Complete");
            Save Save10 = new Save($@"{baseDir}\{tar}", $@"{baseDir}\{scr}\SubDir\Pas save 2.txt", "Save10", "Differential");
            Save Save11 = new Save($@"{baseDir}\{tar}\SubDir\", $@"{baseDir}\{scr}\need to update 3.txt", "Save11", "Complete");
            Save Save12 = new Save($@"{baseDir}\{tar}\SubDir\", $@"{baseDir}\{scr}\need to update 3.txt", "Save12", "Differential");

            List<string> verification1 = new List<string>()      // We create list which will contains the files to backup
            {
                $@"{baseDir}\{scr}\need to update 1.txt",
                $@"{baseDir}\{scr}\need to update 3.txt",
                $@"{baseDir}\{scr}\Pas save 1.txt",
                $@"{baseDir}\{scr}\Save 2.txt",
                $@"{baseDir}\{scr}\Save 3.txt",
                $@"{baseDir}\{scr}\SubDir\need to update 2.txt",
                $@"{baseDir}\{scr}\SubDir\Pas save 2.txt",
                $@"{baseDir}\{scr}\SubDir\Pas save 3.txt",
                $@"{baseDir}\{scr}\SubDir\Save 1.txt"
            };

            List<string> verification2 = new List<string>()
            {
                $@"{baseDir}\{scr}\need to update 1.txt",
                $@"{baseDir}\{scr}\need to update 3.txt",
                $@"{baseDir}\{scr}\Pas save 1.txt",
                $@"{baseDir}\{scr}\SubDir\need to update 2.txt",
                $@"{baseDir}\{scr}\SubDir\Pas save 2.txt",
                $@"{baseDir}\{scr}\SubDir\Pas save 3.txt",
            };

            List<string> verification3 = new List<string>()
            {
                $@"{baseDir}\{scr}\SubDir\need to update 2.txt",
                $@"{baseDir}\{scr}\SubDir\Pas save 2.txt",
                $@"{baseDir}\{scr}\SubDir\Pas save 3.txt",
                $@"{baseDir}\{scr}\SubDir\Save 1.txt"
            };

            List<string> verification4 = new List<string>()
            {
                $@"{baseDir}\{scr}\SubDir\need to update 2.txt",
                $@"{baseDir}\{scr}\SubDir\Pas save 2.txt",
                $@"{baseDir}\{scr}\SubDir\Pas save 3.txt"
            };

            List<string> verification5 = new List<string>()
            {
                $@"{baseDir}\{scr}\need to update 1.txt",
                $@"{baseDir}\{scr}\need to update 3.txt",
                $@"{baseDir}\{scr}\Pas save 1.txt",
                $@"{baseDir}\{scr}\Save 2.txt",
                $@"{baseDir}\{scr}\Save 3.txt",
                $@"{baseDir}\{scr}\SubDir\need to update 2.txt",
                $@"{baseDir}\{scr}\SubDir\Pas save 2.txt",
                $@"{baseDir}\{scr}\SubDir\Pas save 3.txt",
                $@"{baseDir}\{scr}\SubDir\Save 1.txt"
            };

            List<string> verification6 = new List<string>()
            {
                $@"{baseDir}\{scr}\need to update 1.txt",
                $@"{baseDir}\{scr}\need to update 3.txt",
                $@"{baseDir}\{scr}\Pas save 1.txt",
                $@"{baseDir}\{scr}\Save 2.txt",
                $@"{baseDir}\{scr}\SubDir\need to update 2.txt",
                $@"{baseDir}\{scr}\SubDir\Pas save 2.txt",
                $@"{baseDir}\{scr}\SubDir\Pas save 3.txt",
                $@"{baseDir}\{scr}\SubDir\Save 1.txt"
            };

            List<string> verification7 = new List<string>()
            {
                $@"{baseDir}\{scr}\Save 2.txt"
            };

            List<string> verification8 = new List<string>()
            {
                // Nothing here because it's a differential backup and the last write time is the same for target and source file
            };

            List<string> verification9 = new List<string>()
            {
                $@"{baseDir}\{scr}\SubDir\Pas save 2.txt"
            };

            List<string> verification10 = new List<string>()
            {
                $@"{baseDir}\{scr}\SubDir\Pas save 2.txt"
            };

            List<string> verification11 = new List<string>()
            {
                $@"{baseDir}\{scr}\need to update 3.txt"
            };

            List<string> verification12 = new List<string>()
            {
                $@"{baseDir}\{scr}\need to update 3.txt"
            };

            Assert.Equal(verification1, Save1.GetFiles());   // We check if the FilesToBackup attribute is equal to the list that we have created
            Assert.Equal(verification2, Save2.GetFiles());
            Assert.Equal(verification3, Save3.GetFiles());
            Assert.Equal(verification4, Save4.GetFiles());
            Assert.Equal(verification5, Save5.GetFiles());
            Assert.Equal(verification6, Save6.GetFiles());
            Assert.Equal(verification7, Save7.GetFiles());
            Assert.Equal(verification8, Save8.GetFiles());
            Assert.Equal(verification9, Save9.GetFiles());
            Assert.Equal(verification10, Save10.GetFiles());
            Assert.Equal(verification11, Save11.GetFiles());
            Assert.Equal(verification12, Save12.GetFiles());

         

        }

        [Fact]
        public void Step01_InitializeTotalSizeOfFilesToBackupInConstructor()   // This method will test if the initialization of TotalSizeOfFilesToBackup attribute is correct when a object Save is create
        {
            var baseDir = @"\\SelectFilesToBackup_TEST";
            var scr = "DirSource";
            var tar = "DirTarget";

            Save Save1 = new Save($@"{baseDir}\{tar}\", $@"{baseDir}\{scr}\", "Save1", "Complete");     // Creation of an object Save
            Save Save2 = new Save($@"{baseDir}\{tar}\", $@"{baseDir}\{scr}\", "Save2", "Differential");
            Save Save3 = new Save($@"{baseDir}\{tar}\", $@"{baseDir}\{scr}\SubDir\", "Save3", "Complete");
            Save Save4 = new Save($@"{baseDir}\{tar}\", $@"{baseDir}\{scr}\SubDir\", "Save4", "Differential");
            Save Save5 = new Save($@"{baseDir}\{tar}\SubDir\", $@"{baseDir}\{scr}\", "Save5", "Complete");
            Save Save6 = new Save($@"{baseDir}\{tar}\SubDir\", $@"{baseDir}\{scr}\", "Save6", "Differential");
            Save Save7 = new Save($@"{baseDir}\{tar}\", $@"{baseDir}\{scr}\Save 2.txt", "Save7", "Complete");
            Save Save8 = new Save($@"{baseDir}\{tar}\", $@"{baseDir}\{scr}\Save 2.txt", "Save8", "Differential");
            Save Save9 = new Save($@"{baseDir}\{tar}\", $@"{baseDir}\{scr}\SubDir\Pas save 2.txt", "Save9", "Complete");
            Save Save10 = new Save($@"{baseDir}\{tar}\", $@"{baseDir}\{scr}\SubDir\Pas save 2.txt", "Save10", "Differential");
            Save Save11 = new Save($@"{baseDir}\{tar}\SubDir\", $@"{baseDir}\{scr}\need to update 3.txt", "Save11", "Complete");
            Save Save12 = new Save($@"{baseDir}\{tar}\SubDir\", $@"{baseDir}\{scr}\need to update 3.txt", "Save12", "Differential");

            long verificationSize1 = 99;    // We create long which contains the total size of files to backup
            long verificationSize2 = 66;
            long verificationSize3 = 44;
            long verificationSize4 = 33;
            long verificationSize5 = 99;
            long verificationSize6 = 88;
            long verificationSize7 = 11;
            long verificationSize8 = 0;
            long verificationSize9 = 11;
            long verificationSize10 = 11; 
            long verificationSize11 = 11;
            long verificationSize12 = 11;

            Assert.Equal(verificationSize1, Save1.GetSize());     // We check if the FilesToBackup attribute is equal to the long that we have created
            Assert.Equal(verificationSize2, Save2.GetSize());
            Assert.Equal(verificationSize3, Save3.GetSize());
            Assert.Equal(verificationSize4, Save4.GetSize());
            Assert.Equal(verificationSize5, Save5.GetSize());
            Assert.Equal(verificationSize6, Save6.GetSize());
            Assert.Equal(verificationSize7, Save7.GetSize());
            Assert.Equal(verificationSize8, Save8.GetSize());
            Assert.Equal(verificationSize9, Save9.GetSize());
            Assert.Equal(verificationSize10, Save10.GetSize());
            Assert.Equal(verificationSize11, Save11.GetSize());
            Assert.Equal(verificationSize12, Save12.GetSize());

            

        }

        [Fact]
        public void Step02_InitializeFilesToBackup()    //This method will test if the initialization of SelectFilesToBackup is correct when the method is called 
        {
            var baseDir = @"\\SelectFilesToBackup_TEST";
            var scr = "DirSource";
            var tar = "DirTarget";

            Save Save1 = new Save($@"{baseDir}\{tar}\", $@"{baseDir}\{scr}\", "Save1", "Complete");  // Creation of an object Save
            Save Save2 = new Save($@"{baseDir}\{tar}\", $@"{baseDir}\{scr}\SubDir\", "Save4", "Differential");
            
            Save1.Source = $@"{baseDir}\{scr}\SubDir\";  // We change the value of Source attribute
            Save1.GetInitFiles();   // We call the method for initialize the FilesToBackup attribute

            Save2.Source = $@"{baseDir}\{scr}\";
            Save2.GetInitFiles();

            List<string> verificationFiles1 = new List<string>()   // We create the list which contains the new files to backup
            {
                $@"{baseDir}\{scr}\SubDir\need to update 2.txt",
                $@"{baseDir}\{scr}\SubDir\Pas save 2.txt",
                $@"{baseDir}\{scr}\SubDir\Pas save 3.txt",
                $@"{baseDir}\{scr}\SubDir\Save 1.txt"
            };

            long verificationSize1 = 44;

            List<string> verificationFiles2 = new List<string>()
            {
                $@"{baseDir}\{scr}\need to update 1.txt",
                $@"{baseDir}\{scr}\need to update 3.txt",
                $@"{baseDir}\{scr}\Pas save 1.txt",
                $@"{baseDir}\{scr}\SubDir\need to update 2.txt",
                $@"{baseDir}\{scr}\SubDir\Pas save 2.txt",
                $@"{baseDir}\{scr}\SubDir\Pas save 3.txt",
            };

            long verificationSize2 = 66;

            Assert.Equal(verificationFiles1, Save1.GetFiles()); //  We check if the FilesToBackup attribute is equal to the list that we have created
            Assert.Equal(verificationSize1, Save1.GetSize()); //  We check if the TotalF attribute is equal to the list that we have created
            Assert.Equal(verificationFiles2, Save2.GetFiles());
            Assert.Equal(verificationSize2, Save2.GetSize());

            Directory.Delete(baseDir, true);

        }

        [Fact]
        public void Step04_verifyIfBusinessSoftwareIsStarted()    //This method will test if the business software started are in the list which return all the business softwares started
        {
            var baseDir = @"\\SelectFilesToBackup_TEST";
            var scr = "DirSource";
            var tar = "DirTarget";
            Save Save1 = new Save($@"{baseDir}\{tar}\", $@"{baseDir}\{scr}\", "Save1", "Complete");  // Creation of an object Save

            Process calculatrice = new Process();
            calculatrice.StartInfo.FileName = @"C:\Windows\System32\calc.exe";
            calculatrice.Start();
            string filename = @"C:\Windows\System32\calc.exe";


            Assert.Contains(filename, Save1.verifyIfBusinessSoftwareIsStarted());

            calculatrice.Kill();

            Assert.DoesNotContain(filename, Save1.verifyIfBusinessSoftwareIsStarted());

        }


        [Fact]
        public void Step05_ProcessExecutablesPaths()    //This method will test if the business software started are in the list which return all the business softwares started
        {
            List<Process> liste = Process.GetProcesses().ToList();
       
            var baseDir = @"\\SelectFilesToBackup_TEST";
            var scr = "DirSource";
            var tar = "DirTarget";
            Save Save1 = new Save($@"{baseDir}\{tar}\", $@"{baseDir}\{scr}\", "Save1", "Complete");  // Creation of an object Save

            string fullPathCMD = @"C:\Windows\System32\cmd.exe";
            Process CMD = new Process();
            CMD.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
            CMD.Start();

           List<string> resultat = Save1.ProcessExecutablesPaths(liste);

            Assert.Contains(fullPathCMD, resultat);

        }
    }
}
