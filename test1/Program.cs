using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------主线程启动-------");
            Task<int> task = GetStrLengthAsync();
            Console.WriteLine("主线程继续执行");
            Console.WriteLine("Task返回的值" + task.Result);
            Console.WriteLine("-------主线程结束-------");
            Console.ReadKey();
        }
        static async Task<int> GetStrLengthAsync()
        {
            Console.WriteLine("GetStrLengthAsync方法开始执行");
            //此处返回的<string>中的字符串类型，而不是Task<string>
            string str = await GetString();
            Console.WriteLine("GetStrLengthAsync方法执行结束");
            return str.Length;
        }

        static Task<string> GetString()
        {
            Console.WriteLine("GetString方法开始执行");
            return Task<string>.Run(() =>
            {
                Thread.Sleep(2000);
                return "GetString的返回值";
            });
        }
    }
}
