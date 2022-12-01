using System;
using System.Diagnostics;

namespace Cryptosoft
{
    internal class Cryptosoft
    {
        static int Main(string[] args)
        {
            try
            {
                //stopwatch is used to count the encryption time
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                Encryptor encryptor = new Encryptor();
                //encryptDecrypt execute the method to encrypt and decrypt differents file
                encryptor.encryptDecrypt(args[0], args[1]);

                stopwatch.Stop();

                return (int)stopwatch.ElapsedMilliseconds;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
