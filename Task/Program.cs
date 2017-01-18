using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDemo
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    CancellationTokenSource cts = new CancellationTokenSource();
        //    Task<int> t = new Task<int>(() => Add(cts.Token), cts.Token);
        //    Task<int> t = new Task<int>(()=> AddCancleByThrow(cts.Token), cts.Token);
        //    t.Start();
        //    t.ContinueWith(TaskEnded);
        //    Console.ReadKey();
        //    cts.Cancel();
        //    Console.ReadKey();
        //}

        //static void TaskEnded(Task<int> task)
        //{
        //    Console.WriteLine("任务完成，完成时候的状态：");
        //    Console.WriteLine("isCancelled={0} \t IsCompleted={1} \t ISFaulted={2}", task.IsCanceled, task.IsCompleted, task.IsFaulted);
        //    Console.WriteLine("任务的返回值：{0}", task.Result);
        //}

        //static int Add(CancellationToken ct)
        //{
        //    Console.WriteLine("任务开始。。。");
        //    int result = 0;
        //    while (!ct.IsCancellationRequested)
        //    {
        //        result++;
        //        Thread.Sleep(1000);
        //    }
        //    return result;
        //}

        static void Main(string[] args)
        {
            //CancellationTokenSource cts = new CancellationTokenSource();
            //Task<int> t = new Task<int>(() => AddCancleByThrow(cts.Token), cts.Token);
            //t.Start();
            //t.ContinueWith(TaskEndedbyCatch);
            //Console.ReadKey();
            //cts.Cancel();
            //Console.ReadKey();
            M1();
            Console.ReadKey();
        }

        static void TaskEndedbyCatch(Task<int> task)
        {
            Console.WriteLine("任务完成，完成时候的状态：");
            Console.WriteLine("isCancelled={0} \t IsCompleted={1} \t ISFaulted={2}", task.IsCanceled, task.IsCompleted, task.IsFaulted);
            try
            {
                Console.WriteLine("任务的返回值：{0}", task.Result);
            }
            catch (AggregateException e)
            {
                e.Handle((err) => err is OperationCanceledException);
            }

        }

        static int AddCancleByThrow(CancellationToken ct)
        {
            Console.WriteLine("任务开始。。。");
            int result = 0;
            while (!ct.IsCancellationRequested)
            {
                ct.ThrowIfCancellationRequested();
                result++;
                Thread.Sleep(1000);
            }
            return result;
        }

        private static int count = 0;
        //用async和await保证多线程下静态变量count安全
        public async static void M1()
        {
            //async and await将多个线程进行串行处理
            //等到await之后的语句执行完成后
            //才执行本线程的其他语句
            //step 2

            await Task.Run(new Action(M2));
            Console.WriteLine("Current Thread ID is {0}", System.Threading.Thread.CurrentThread.ManagedThreadId);
            //step 6
            count++;
            //step 7
            Console.WriteLine("M1 Step is {0}", count);
        }

        public static void M2()
        {
            Console.WriteLine("Current Thread ID is {0}", System.Threading.Thread.CurrentThread.ManagedThreadId);
            //step 3
            System.Threading.Thread.Sleep(3000);
            //step 4
            count++;
            //step 5
            Console.WriteLine("M2 Step is {0}", count);
        }

    }
}
