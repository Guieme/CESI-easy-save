using Xunit;
using EasySaveApp;
using EasySaveApp.View;
using EasySaveApp.Model;
using EasySaveApp.ViewModel;
using System.Collections.Generic;
using System.IO;

namespace EasySaveTests
{
    [Collection("Sequential")]
    public class ViewModel_Tests
    {
        static readonly DisplayMenu disp = EasySaveApp.View.DisplayMenu.GetView();

        [Fact]
        //ChangeLanguageTest permit to test if the good language is taken in return of the inserted data
        public void ChangeLanguageTest()
        {
            MainViewModel.saves = new List<Save>();
            Assert.Equal("English", Menu.GetMenu().ChangeLanguage("1"));
            Assert.Equal("French", Menu.GetMenu().ChangeLanguage("2"));
            Assert.Equal("English", Menu.GetMenu().ChangeLanguage("abc"));
        }

        [Fact]
        //EnAddBackupTest permit to test if the backup's add really works
        public void EnAddBackupTest()
        {
            MainViewModel.saves = new List<Save>();
            
            var dirPath = @"C:\Users\Public\Temp";
            var SourcePath = @"C:\Users\Public\Temp\Dir1";

            Directory.CreateDirectory(dirPath);
            Directory.CreateDirectory(SourcePath);

            EnglishMenu.GetEnglishMenu().EnAddBackup(disp, "Save1", SourcePath, dirPath, "1");

            Assert.Equal("Save1", MainViewModel.saves[0].Name);
            Assert.Equal(SourcePath, MainViewModel.saves[0].Source);
            Assert.Equal(dirPath, MainViewModel.saves[0].Target);
            Assert.Equal("Complete", MainViewModel.saves[0].Type);

            EnglishMenu.GetEnglishMenu().EnAddBackup(disp, "Save2", SourcePath, dirPath, "2");

            Assert.Equal("Save2", MainViewModel.saves[1].Name);
            Assert.Equal(SourcePath, MainViewModel.saves[1].Source);
            Assert.Equal(dirPath, MainViewModel.saves[1].Target);
            Assert.Equal("Differential", MainViewModel.saves[1].Type);

            EnglishMenu.GetEnglishMenu().EnAddBackup(disp, "Save3", SourcePath, dirPath, "abc");

            Assert.Equal("Save3", MainViewModel.saves[2].Name);
            Assert.Equal(SourcePath, MainViewModel.saves[2].Source);
            Assert.Equal(dirPath, MainViewModel.saves[2].Target);
            Assert.Equal("Complete", MainViewModel.saves[2].Type);

            Directory.Delete(dirPath, true);
        }

        [Fact]
        //EnUpdateBackupTest permit to test if the backup's update really works
        public void EnUpdateBackupTest()
        {
            MainViewModel.saves = new List<Save>();

            var dirPath = @"C:\Users\Public\Temp";
            var SourcePath = @"C:\Users\Public\Temp\Dir1";
            Directory.CreateDirectory(dirPath);
            Directory.CreateDirectory(SourcePath);

            EnglishMenu.GetEnglishMenu().EnAddBackup(disp, "Save1", SourcePath, dirPath, "1");
            EnglishMenu.GetEnglishMenu().EnUpdateBackup(disp, "1", SourcePath, dirPath, "2", MainViewModel.saves);

            Assert.Equal("Save1", MainViewModel.saves[0].Name);
            Assert.Equal(SourcePath, MainViewModel.saves[0].Source);
            Assert.Equal(dirPath, MainViewModel.saves[0].Target);
            Assert.Equal("Differential", MainViewModel.saves[0].Type);

            Directory.Delete(dirPath, true);
        }

        [Fact]
        //EnDeleteBackupTest permit to test if the backup's delete really works
        public void EnDeleteBackupTest()
        {
            MainViewModel.saves = new List<Save>();

            var dirPath = @"C:\Users\Public\Temp";
            var SourcePath = @"C:\Users\Public\Temp\Dir1";
            Directory.CreateDirectory(dirPath);
            Directory.CreateDirectory(SourcePath);

            EnglishMenu.GetEnglishMenu().EnAddBackup(disp, "Save1", SourcePath, dirPath, "1");
            EnglishMenu.GetEnglishMenu().EnAddBackup(disp, "Save2", SourcePath, dirPath, "1");
            EnglishMenu.GetEnglishMenu().EnAddBackup(disp, "Save3", SourcePath, dirPath, "1");

            Assert.Equal(3, MainViewModel.saves.Count);
            EnglishMenu.GetEnglishMenu().EnDeleteBackup(disp, "1", MainViewModel.saves);
            Assert.Equal(2, MainViewModel.saves.Count);
            EnglishMenu.GetEnglishMenu().EnDeleteBackup(disp, "1", MainViewModel.saves);
            Assert.Single(MainViewModel.saves);
            EnglishMenu.GetEnglishMenu().EnDeleteBackup(disp, "1", MainViewModel.saves);
            Assert.Empty(MainViewModel.saves);

            Directory.Delete(dirPath, true);
        }

        [Fact]
        //FrAddBackupTest permit to test if the backup's add really works
        public void FrAddBackupTest()
        {
            MainViewModel.saves = new List<Save>();

            var dirPath = @"C:\Users\Public\Temp";
            var SourcePath = @"C:\Users\Public\Temp\Dir1";
            Directory.CreateDirectory(dirPath);
            Directory.CreateDirectory(SourcePath); ;

            BackUpViewModel.GetBackUpViewModel().FrAddBackup(disp, "Save1", SourcePath, dirPath, "1");

            Assert.Equal("Save1", MainViewModel.saves[0].Name);
            Assert.Equal(SourcePath, MainViewModel.saves[0].Source);
            Assert.Equal(dirPath, MainViewModel.saves[0].Target);
            Assert.Equal("Complete", MainViewModel.saves[0].Type);

            BackUpViewModel.GetBackUpViewModel().FrAddBackup(disp, "Save2", SourcePath, dirPath, "2");

            Assert.Equal("Save2", MainViewModel.saves[1].Name);
            Assert.Equal(SourcePath, MainViewModel.saves[1].Source);
            Assert.Equal(dirPath, MainViewModel.saves[1].Target);
            Assert.Equal("Differential", MainViewModel.saves[1].Type);

            BackUpViewModel.GetBackUpViewModel().FrAddBackup(disp, "Save3", SourcePath, dirPath, "abc");

            Assert.Equal("Save3", MainViewModel.saves[2].Name);
            Assert.Equal(SourcePath, MainViewModel.saves[2].Source);
            Assert.Equal(dirPath, MainViewModel.saves[2].Target);
            Assert.Equal("Complete", MainViewModel.saves[2].Type);

            Directory.Delete(dirPath, true);
        }

        [Fact]
        //FrUpdateBackupTest permit to test if the backup's update really works
        public void FrUpdateBackupTest()
        {
            MainViewModel.saves = new List<Save>();

            var dirPath = @"C:\Users\Public\Temp";
            var SourcePath = @"C:\Users\Public\Temp\Dir1";
            Directory.CreateDirectory(dirPath);
            Directory.CreateDirectory(SourcePath);

            BackUpViewModel.GetBackUpViewModel().FrAddBackup(disp, "Save1", SourcePath, dirPath, "1");
            BackUpViewModel.GetBackUpViewModel().FrUpdateBackup(disp, "1", SourcePath, dirPath, "2", MainViewModel.saves);

            Assert.Equal("Save1", MainViewModel.saves[0].Name);
            Assert.Equal(SourcePath, MainViewModel.saves[0].Source);
            Assert.Equal(dirPath, MainViewModel.saves[0].Target);
            Assert.Equal("Differential", MainViewModel.saves[0].Type);

            Directory.Delete(dirPath, true);
        }

        [Fact]
        //FrDeleteBackupTest permit to test if the backup's delete really works
        public void FrDeleteBackupTest()
        {
            MainViewModel.saves = new List<Save>();

            var dirPath = @"C:\Users\Public\Temp";
            var SourcePath = @"C:\Users\Public\Temp\Dir1";
            Directory.CreateDirectory(dirPath);
            Directory.CreateDirectory(SourcePath);

            BackUpViewModel.GetBackUpViewModel().FrAddBackup(disp, "Save1", SourcePath, dirPath, "1");
            BackUpViewModel.GetBackUpViewModel().FrAddBackup(disp, "Save2", SourcePath, dirPath, "1");
            BackUpViewModel.GetBackUpViewModel().FrAddBackup(disp, "Save3", SourcePath, dirPath, "1");

            Assert.Equal(3, MainViewModel.saves.Count);
            BackUpViewModel.GetBackUpViewModel().FrDeleteBackup(disp, "1", MainViewModel.saves);
            Assert.Equal(2, MainViewModel.saves.Count);
            BackUpViewModel.GetBackUpViewModel().FrDeleteBackup(disp, "1", MainViewModel.saves);
            Assert.Single(MainViewModel.saves);
            BackUpViewModel.GetBackUpViewModel().FrDeleteBackup(disp, "1", MainViewModel.saves);
            Assert.Empty(MainViewModel.saves);

            Directory.Delete(dirPath, true);
        }
    }
}
