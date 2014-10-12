using System;
using System.Threading;
namespace WaitUntilDonePattern
{
    delegate long MyDel( int first, int second);

    class Program
    {
        static long Sum(int x, int y)
        {
            Console.WriteLine(".........Inside Sum");
            Thread.Sleep(5000);

            return x + y;
        }

        static void Main(string[] args)
        {
            MyDel del = new MyDel(Sum);

            Console.WriteLine("Before BeginInvoke");
            IAsyncResult iar = del.BeginInvoke(3, 5, null, null);
            Console.WriteLine("After BeginInvoke");

            Console.WriteLine("Doing Some Stuff");

            long result = del.EndInvoke(iar);
            Console.WriteLine("After EndInvoke: {0}", result);
            Console.ReadLine();
        }
    }
}
