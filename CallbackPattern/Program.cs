using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace CallbackPattern
{
    delegate long MyDel(int first, int second);

    class Program
    {
        static long Sum(int x, int y)
        {
            Console.WriteLine(".........Inside Sum");
            Thread.Sleep(100);

            return x + y;
        }

        static void CallWhenDone(IAsyncResult iar)
        {
            Console.WriteLine(".........Inside Callback");
            AsyncResult ar = (AsyncResult)iar;
            MyDel del = (MyDel)ar.AsyncDelegate;

            long result = del.EndInvoke(iar);
            Console.WriteLine(".........After EndInvoke: {0}", result);
        }

        static void Main(string[] args)
        {
            MyDel del = new MyDel(Sum);

            Console.WriteLine("Before BeginInvoke");
            IAsyncResult iar = del.BeginInvoke(3, 5, new AsyncCallback(CallWhenDone), null);
            Console.WriteLine("After BeginInvoke");

            Console.WriteLine("Doing Some Stuff");
            Thread.Sleep(500);
            Console.WriteLine("Done with main");
            Console.ReadLine();      
        }
    }
}
