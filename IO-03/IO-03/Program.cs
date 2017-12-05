using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_03
{
    class Program
    {
        static void ConsolePrint(string text)
        {
            Console.WriteLine(text);
        }
        static void Main(string[] args)
        {
            
            Zadania zadania = new Zadania();
            Task task = Zadania.contentDownloader(new Uri("http://www.feedforall.com/sample.xml"));
            task.Wait();
        }

        

       

        
    }
}
