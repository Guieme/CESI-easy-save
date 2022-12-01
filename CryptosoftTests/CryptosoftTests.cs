using System;
using System.IO;
using Xunit;
using Cryptosoft;
using System.Text;

namespace CryptosoftTests
{
    public class UnitTest1
    {
        [Fact]
        public void EncryptTest()
        {
            File.WriteAllText("D:/test.txt", "azertyuiop");

            Encryptor encryptor = new Encryptor();
            //encryptDecrypt execute the method to encrypt and decrypt differents file
            encryptor.encryptDecrypt("D:/test.txt", "D:/encrypt.txt");
            Encryptor encryptor2 = new Encryptor();
            encryptor2.encryptDecrypt("D:/encrypt.txt", "D:/decrypt.txt");


            Assert.Equal(File.ReadAllText("D:/decrypt.txt"), File.ReadAllText("D:/test.txt"));
            Assert.NotEqual(File.ReadAllText("D:/encrypt.txt"), File.ReadAllText("D:/test.txt"));

            File.Delete("D:/test.txt");
            File.Delete("D:/encrypt.txt");
            File.Delete("D:/decrypt.txt");
        }
    }
}