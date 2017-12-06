using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_IO_4
{
    class ServerTapClass
    {
        TcpListener serverListener;
        Task taskServer;
        int port;
        IPAddress address;
        bool processRunning = false;

        public Task TaskServer
        {
            get
            {
                return taskServer;
            }
        }

        public IPAddress Address
        {
            get
            {
                return address;
            }
            set
            {
                if (!processRunning)
                {
                    address = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        CancellationTokenSource token = new CancellationTokenSource();
        public ServerTapClass(IPAddress ipAddress)
        {
            this.address = ipAddress;
            port = 2048;
        }

        async public Task serverTaskRun()
        {
            this.serverListener = new TcpListener(IPAddress.Any, 2048);
            serverListener.Start();
            while (true)
            {
                TcpClient tcpClient = await serverListener.AcceptTcpClientAsync();
                byte[] buffer = new byte[1024];
                await tcpClient.GetStream().ReadAsync(buffer, 0, buffer.Length).ContinueWith(
                    async (x) =>
                    {
                        int i = x.Result;
                        while (true)
                        {
                            tcpClient.GetStream().WriteAsync(buffer, 0, i);
                            i = await tcpClient.GetStream().ReadAsync(buffer, 0, buffer.Length);
                            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, i));
                        }
                    });
            }
        }

        



    }
}
