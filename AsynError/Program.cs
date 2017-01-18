using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynError
{
    class Program
    {
        static void Main(string[] args)
        {
            //DontHandle1();
            //DontHandle();
            ShowAggregatedException();
            Console.ReadLine();
        }

        static async Task ThrowAfter(int ms, string message)
        {
            await Task.Delay(ms);
            throw new Exception(message);
        }

        private static void DontHandle1()
        {
            try
            {
                ThrowAfter(200, "first");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static async void DontHandle()
        {
            try
            {
                await ThrowAfter(200, "first");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static async void ShowAggregatedException()
        {
            Task taskResult = null;
            try
            {
                Task t1 = ThrowAfter(2000, "first");
                Task t2 = ThrowAfter(1000, "second");
                await (taskResult = Task.WhenAll(t1, t2));
            }
            catch ( Exception ex)
            {
                Console.WriteLine("handled {0}", ex.Message);
                foreach (var ex1 in taskResult.Exception.InnerExceptions)
                {
                    Console.WriteLine("inner exception {0}", ex1.Message);
                }
            }
        }
    }
}
