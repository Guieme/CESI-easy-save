using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace EasySaveApp.Networking
{
    public class Communication
    {
        static Socket server;
        static byte[] bytes = new byte[1024];
        static string data = null;
        public static Socket client;
        public static Semaphore sendSemaphore = new Semaphore(1, 1);
        public static void InitServer()
        {
            //Initialize ip address and port of the server
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint LocalEP = new IPEndPoint(ipAddress, 55979);

            //Initialize th socket of the server
            server = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(LocalEP);
            server.Listen(2);
        }
        public static void AcceptClient()
        {
            client = server.Accept(); 
        }
        public static string ReceiveData()
        {
            int bytesRec = client.Receive(bytes);
            data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            return data;
        }
        public static void SendData(string data)
        {
            if (client != null)
            {
                client.Send(Encoding.ASCII.GetBytes(data));
                Thread.Sleep(200);
            }
        }
    }
}
