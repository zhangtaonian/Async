using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
           
            CallerWithAsync();
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(300);
                Console.WriteLine("i");
            }
            Console.ReadLine();
        }

        static string Greeting(string name)
        {
            Thread.Sleep(3000);
            return string.Format("Hello,{0}", name); 
        }
        //创建任务
        static Task<string> GreetingAsync (string name)
        {
            return Task.Run<string>(() =>
            {
                return Greeting(name);
            });
        }
        //
        private async static void CallerWithAsync()
        {
            string result = await GreetingAsync("hello body");
            Console.WriteLine(result);
        }



    }
}
