using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IO_03
{
    class Zadania
    {
        //Zadanie13
        public void Zadanie13()
        {
            

            Task.Run(
                () =>
                {
                    bool Z2 = true;
                    
                });

        }

        //Zadanie14
        public static async Task contentDownloader(Uri url)
        {
            WebClient webClient = new WebClient();
            try
            {
                string pageContent = await webClient.DownloadStringTaskAsync(url);
                Console.WriteLine(pageContent);
            }
            catch(WebException webException)
            {
                Console.WriteLine(webException.Message);
            }
        }











    }
}
