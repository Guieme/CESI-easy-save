using EasySaveApp.Model;
using EasySaveApp.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace EasySaveTests.Model
{
    [Collection("Sequential")]
    public class InputTests
    {
        [Fact]
        public void step00_CheckInputNumberTest()
        {
            Input input = new Input();
            Assert.Equal(2, input.CheckInputNumber("2"));
            Assert.Equal(0, input.CheckInputNumber("9"));
            Assert.Equal(0, input.CheckInputNumber("abc"));

        }

        [Fact]
        public void step01_CheckInputbackupTest()
        {
            var dirPath = @"C:\Users\Public\Temp";
            Directory.CreateDirectory(dirPath);

            Input input = new Input();
            List<Save> saves = new List<Save>();

            Save save1 = new Save(@"C:\Users\Public\Temp", @"C:\Users\Public\Temp", "Save1", "Complete");
            Save save2 = new Save(@"C:\Users\Public\Temp", @"C:\Users\Public\Temp", "Save2", "Complete");
            Save save3 = new Save(@"C:\Users\Public\Temp", @"C:\Users\Public\Temp", "Save3", "Complete");

            saves.Add(save1);
            saves.Add(save2);
            saves.Add(save3);

            Assert.Equal(2, input.CheckInputbackup(saves, 2));
            Assert.Equal(0, input.CheckInputbackup(saves, 9));
            Assert.Equal(0, input.CheckInputbackup(saves, 0));

            Directory.Delete(dirPath, true);
        }

        [Fact]
        public void step02_IsDirTest()
        {
            var dirPath = @"C:\Users\Public\Temp";
            var filePath = dirPath + @"\test.json";

            if (Directory.Exists(dirPath))
            {
                Directory.Delete(dirPath, true);
            }
            Directory.CreateDirectory(dirPath);
            var file = File.Create(filePath);

            Assert.True(Input.IsDir(dirPath));
            Assert.False(Input.IsDir(filePath));

            file.Close();
            File.Delete(filePath);
            Directory.Delete(dirPath);
        }
        [Fact]
        public void step03_VerifyPath_Test()
        {

            var ValidPath = @"C:\Users\Public\Temp";
            var BadEndingPath = @"C:\Users\Public\Temp\";
            var InvalidPath = @"C:\Windows\invalid_path";

            if (Directory.Exists(ValidPath))
            {
                Directory.Delete(ValidPath, true);
            }
            Directory.CreateDirectory(ValidPath);

            Assert.True(Input.VerifyPath(ValidPath, 1));
            Assert.True(Input.VerifyPath(BadEndingPath, 0));
            Assert.False(Input.VerifyPath(InvalidPath , 1));

            Directory.Delete(ValidPath, true);
        }
        [Fact]
        public void step04_VerifySaveTest()
        {
            MainViewModel.saves = new List<Save>();
            var save1 = new Save(@"C:\Users\Public\Temp", @"C:\Users\Public\Temp", "Save1", "Complete");
            var save2 = new Save(@"C:\Users\Public\Temp", @"C:\Users\Public\Temp", "Save2", "Complete");
            var save3 = new Save(@"C:\Users\Public\Temp", @"C:\Users\Public\Temp", "Save3", "Complete");
            var save4 = new Save(@"C:\Users\Public\Temp", @"C:\Users\Public\Temp", "Save4", "Complete");
            var save5 = new Save(@"C:\Users\Public\Temp", @"C:\Users\Public\Temp", "Save5", "Complete");
            var save6 = new Save(@"C:\Users\Public\Temp", @"C:\Users\Public\Temp", "Save6", "Complete");

            Assert.True(Input.VerifySave(save1.Name));
            MainViewModel.saves.Add(save1);
            Assert.False(Input.VerifySave(save1.Name));
            MainViewModel.saves.Add(save2);
            MainViewModel.saves.Add(save3);
            MainViewModel.saves.Add(save4);
            MainViewModel.saves.Add(save5);
            MainViewModel.saves.Add(save6);
            Assert.Equal(6, MainViewModel.saves.Count);
            Assert.True(MainViewModel.saves.Count > 5);
        }
    }
}
