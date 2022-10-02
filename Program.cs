using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        private static object _MessageLock = new object();

        public static void WriteMessage(string message, ConsoleColor c1)
        {
            lock (_MessageLock)
            {
                Console.BackgroundColor = c1;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
        static void Main(string[] args)
        {
            counter();
            counter2();
            Console.ReadLine();
        }
        public static async void counter()
        {
            await Task.Run(() =>
            {
                for(int i=0; i<100; i++)
                {
                    if(i % 10 == 0) { Console.Clear(); }
                    Thread.Sleep(1000);
                    WriteMessage("Worker#1 =>" + i,ConsoleColor.Green);
                }
            });
        }
        public static async void counter2()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i > -100; i--)
                {
                    if (i % 10 == 0) { Console.Clear(); }
                    Thread.Sleep(1000);
                    WriteMessage("Worker#2 =>" + i, ConsoleColor.Red);
                }
            });
        }
    }
}
