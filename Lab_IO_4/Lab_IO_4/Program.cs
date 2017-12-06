using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_IO_4
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerTapClass server = new ServerTapClass(IPAddress.Any);
            ClientTapClass client1 = new ClientTapClass();
            var x = server.serverTaskRun();
            CancellationTokenSource cancellationToken1 = new CancellationTokenSource();
            client1.ConnectClient();
            var y = client1.keepPinging("Testowa wiadomosc", cancellationToken1.Token);

            cancellationToken1.CancelAfter(4000);
            Task.WaitAll(x, y);

        }
    }
}
