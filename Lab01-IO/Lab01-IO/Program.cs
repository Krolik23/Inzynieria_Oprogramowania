using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab01_IO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Zadanie 1
            //ThreadPool.QueueUserWorkItem(ThreadProc,1000);
            //ThreadPool.QueueUserWorkItem(ThreadProc,2000);
            //Thread.Sleep(4000);


            ThreadPool.QueueUserWorkItem(connectServer);
            ThreadPool.QueueUserWorkItem(connectClient);
            ThreadPool.QueueUserWorkItem(connectClient);

            Thread.Sleep(1000);













        }

        //Zadanie 1 
        //static void ThreadProc(Object stateInfo){
        //    Thread.Sleep((int)stateInfo);
        //    Console.WriteLine("I waited: " + (int)stateInfo);
        //}

        static void connectServer(Object stateInfo)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 2048);
            server.Start();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                

                byte[] buffer = new byte[1024];
                client.GetStream().Read(buffer, 0, 1024);
                client.GetStream().Write(buffer, 0, buffer.Length);

                string result = Encoding.UTF8.GetString(buffer);

                writeConsoleMessage("Serwer: " + result, ConsoleColor.Red);


            }
        }

        static void connectClient(Object stateInfo)
        {
            TcpClient client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2048));


            byte[] message = new ASCIIEncoding().GetBytes("wiadomosc");
            client.GetStream().Write(message, 0, message.Length);
            client.GetStream().Read(message, 0, message.Length);

            string result = Encoding.UTF8.GetString(message);

            writeConsoleMessage("Klient: " + result, ConsoleColor.Green);



        }


        static void writeConsoleMessage(string message, ConsoleColor color)
        {
            //lock (thisLock)
            //{
                Console.ForegroundColor = color;
                Console.WriteLine(message);
                Console.ResetColor();
            //}
        }




    }
}
