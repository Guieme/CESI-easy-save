using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using EasySaveApp_Client.ViewModel;

namespace EasySaveApp_Client.Networking
{
    public class Communication
    {
        public static Socket server;
        static byte[] bytes = new byte[1024];
        static string data = null;
        public static Semaphore SendingSemaphore = new Semaphore(1, 1);
        public static void Connecting()
        {
            //Initialize ip address and port of the server
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 55979);

            //Initialize th socket of the server
            server = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            //Connect the client to the server
            try
            {
                server.Connect(remoteEP);
            }
            catch (Exception)
            {
                UserErrorManagement.ErrorPopUp("Cannot connect to the host");
                Process.GetCurrentProcess().Kill();
            }
            
            
        }

        public static string ReceiveData()
        {
                int bytesRec = server.Receive(bytes);
                data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                return data;
        }
        public static void SendData(string msg)
        {
                server.Send(Encoding.ASCII.GetBytes(msg));
                Thread.Sleep(100);
        }
    }
}
