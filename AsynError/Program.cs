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
            DontHandle();
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
    }
}
