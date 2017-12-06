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
    class ClientTapClass
    {
        TcpClient tcpClient;

        public void ConnectClient()
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2048));

        }

        public async Task<string> Ping(string msg)
        {
            byte[] buffer = new ASCIIEncoding().GetBytes(msg);
            tcpClient.GetStream().WriteAsync(buffer, 0, buffer.Length);
            buffer = new byte[1024];
            var t = await tcpClient.GetStream().ReadAsync(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer, 0, t);
        }

        public async Task<IEnumerable<string>> keepPinging(string msg, CancellationToken cancellationToken)
        {
            List<string> messageList = new List<string>();
            bool operationEnded = false;
            while (!operationEnded)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    operationEnded = true;
                }
                messageList.Add(await Ping(msg));
            }
            return messageList;
        }



    }
}
