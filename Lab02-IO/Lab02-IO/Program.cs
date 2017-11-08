using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab02_IO
{
    class Program
    {
        //=====================Zadanie6==========================
        //static void Main(string[] args)
        //{
        //    string[] path = System.IO.Directory.GetFiles("../../resources/");
        //    byte[] buffer = new byte[1024];
        //    AutoResetEvent are = new AutoResetEvent(false);
        //    FileStream fs = new FileStream(path[0], FileMode.Open);
        //    fs.BeginRead(buffer, 0, buffer.Length, myAsyncCallback, new object[] { fs, buffer, are });
        //    are.WaitOne();

        //}


        //static void myAsyncCallback(IAsyncResult state)
        //{
        //    object[] data = (object[])state.AsyncState;
        //    FileStream fs = (FileStream)data[0];
        //    AutoResetEvent are = (AutoResetEvent)data[2];
        //    byte[] buffer = (byte[])data[1];
        //    int len = fs.EndRead(state);
        //    Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, len));
        //    fs.Close();
        //    are.Set();
        //}
        //=====================Zadanie6===========================

        //====================Zad7==========================

        //static void Main(string[] args)
        //{
        //    string[] path = System.IO.Directory.GetFiles("../../resources/");
        //    byte[] buffer = new byte[1024];
        //    FileStream fs = new FileStream(path[0], FileMode.Open);

        //    IAsyncResult state = fs.BeginRead(buffer, 0, buffer.Length, null, null);
        //    int len = fs.EndRead(state);
        //    Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, len));
        //    fs.Close();


        //}

        //====================Zad7==========================

        //==================Zad8============================

        delegate int DelegateType(int argument);
        static DelegateType recursionFactorialDelegate, iterateFactorialDelegate,
            recursionFibonacciDelegate, iterateFibonacciDelegate;

        static void Main(string[] args)
        {
            recursionFactorialDelegate = new DelegateType(recursionFactorial);
            iterateFactorialDelegate = new DelegateType(iterateFactorial);
            recursionFibonacciDelegate = new DelegateType(recursionFibonacci);
            iterateFibonacciDelegate = new DelegateType(iterateFibonacci);

            IAsyncResult recursionFactorialResult = recursionFactorialDelegate.BeginInvoke(4, null, null);
            IAsyncResult iterateFactorialResult = iterateFactorialDelegate.BeginInvoke(4, null, null);
            IAsyncResult recursionFibonacciResult = recursionFibonacciDelegate.BeginInvoke(4, null, null);
            IAsyncResult iterateFibonacciResult = iterateFibonacciDelegate.BeginInvoke(4, null, null);

            WaitHandle[] waitHandles = new WaitHandle[] {recursionFactorialResult.AsyncWaitHandle, iterateFactorialResult.AsyncWaitHandle,
            recursionFibonacciResult.AsyncWaitHandle, iterateFibonacciResult.AsyncWaitHandle};

            WaitHandle.WaitAll(waitHandles);

            int recursionFactorialValue = recursionFactorialDelegate.EndInvoke(recursionFactorialResult);
            int iterateFactorialValue = iterateFactorialDelegate.EndInvoke(iterateFactorialResult);
            int recursionFibonacciValue = recursionFibonacciDelegate.EndInvoke(recursionFibonacciResult);
            int iterateFibonacciValue = iterateFibonacciDelegate.EndInvoke(iterateFibonacciResult);

            foreach (WaitHandle temp in waitHandles)
            {
                temp.Close();
            }

            Console.WriteLine("Recursion factorial of 4: {0}\nIterate factorial of 4: {1}\nRecursion Fibonacci of 4: {2}\n" +
                "Iterate Fibonacci of 4: {3}\n", recursionFactorialValue, iterateFactorialValue, recursionFibonacciValue,
                iterateFibonacciValue);

        }



        static int recursionFactorial(int x)
        {
            if (x < 0) throw new Exception();
            if (x <= 1) return 1;
            return x * recursionFactorial(x - 1);
        }

        static int iterateFactorial(int x)
        {
            int total = 1;
            if (x < 0) throw new Exception();
            if (x <= 1) return total;
            for (int i = 2; i <= x; i++)
                total *= i;
            return total;

        }

        public static int recursionFibonacci(int position)
        {
            if (position == 0)
                return 0;
            if (position == 1)
                return 1;
            else
                return recursionFibonacci(position - 2) + recursionFibonacci(position - 1);
        }

        public static int iterateFibonacci(int state)
        {
            int a = 0;
            int b = 1;

            for (int i = 0; i < state; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }

        //==================Zad8============================



    }
}
