using System;
using System.Collections.Generic;
using System.Text;
using EasySaveApp.Model;
using Xunit;

namespace EasySaveTests.Model
{
    [Collection("Sequential")]
    public class SettingsTests
    {
        [Fact]
        public void step00_LanguageTest()
        {
            var language = "English";
            Settings.GetSettings().Language = language;

            Assert.Equal(language, Settings.GetSettings().Language);
        }
    }
}
