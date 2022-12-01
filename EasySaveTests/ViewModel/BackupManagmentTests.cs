using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using EasySaveApp.ViewModel;

namespace EasySaveTests.ViewModel
{
    [Collection("Sequential")]
    public class BackupManagmentTests
    {
        [Fact]
        public void step00_InitSoftTest()
        {
            var path = @"\";
            BackupManagment.GetBackupManagment().InitSoft();

            Assert.True(Directory.Exists(path + @"\logs"));
            Assert.True(Directory.Exists(path + @"\Saves"));
            Assert.True(Directory.Exists(path + @"\RealTimeLog"));
        }
        [Fact]
        public void step01_RestoreTests()
        {
            string path = @"\\Saves";
            File.Delete(path + @"\Saves.json"); File.Create(path + @"\Saves.json").Dispose();

            MainViewModel.saves = new List<EasySaveApp.Model.Save>();
            var save = new EasySaveApp.Model.Save(@"C:\Temp", @"C:\Temp\Dir1", "SaveTest", "Complete");
            MainViewModel.saves.Add(save);

            File.Copy(path + @"\Saves.json", @"\\Saves.json", true);
            File.Delete(path + @"\Saves.json");

            Directory.Delete(path, true);
            Directory.CreateDirectory(path);

            BackupManagment.GetBackupManagment().RestoreBackup();

            Assert.Equal(@"C:\Temp", MainViewModel.saves[0].Target);
            Assert.Equal(@"C:\Temp\Dir1", MainViewModel.saves[0].Source);
            Assert.Equal("SaveTest", MainViewModel.saves[0].Name);
            Assert.Equal("Complete", MainViewModel.saves[0].Type);

            File.Delete(path + @"\Saves.json");
            File.Delete(@"\\Saves.json");
        }
    }
}
