using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Diagnostics;

namespace Async_Study
{
    class Program
    {

        //创建计时器
        private static readonly Stopwatch Watch = new Stopwatch();
        static void Main(string[] args)
        {
            //WithoutAsync();
            WhitAsync();
        }

        static string Greeting( string name )
        {
           Task task1= Task.Delay(3000);
            task1.Wait();
        
            return "Hello"+ name;
        }

        static Task<string> GreetingAsync(string name)
        {
            Task<string> mytask= Task.Run<string>(()=> { return Greeting(name); });
            return mytask;
        }

        private async static  void CallerwithAsync()
        {
            string result = await GreetingAsync("House");
           
            Console.WriteLine(result);
        }


        #region  未使用异步编程
        private static void WithoutAsync()
        {
            Watch.Start();
            const string url1 = "http://www.cnblogs.com/";
            const string url2 = "http://www.cnblogs.com/liqingwen/";
            //两次调用 CountCharacters 方法（下载某网站内容，并统计字符的个数）
            var result1 = CountCharacters(1, url1);
            var result2 = CountCharacters(2, url2);
            //三次调用 ExtraOperation 方法（主要是通过拼接字符串达到耗时操作）
             for (var i = 0; i < 3; i++)
            {
                ExtraOperation(i + 1);

            }

            Console.WriteLine($"{url1} 的字符个数：{result1}");
            Console.WriteLine($"{url2} 的字符个数：{result2}");
            Console.Read();
        }


        /// <summary>
        /// 统计字符个数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        private static int CountCharacters(int id, string address)
        {
            WebClient wc = new WebClient();
            Console.WriteLine($"开始调用 id = {id}：{Watch.ElapsedMilliseconds} ms");

            var result = wc.DownloadString(address);
            Console.WriteLine($"调用完成 id = {id}：{Watch.ElapsedMilliseconds} ms");

            return result.Length;
        }

        /// <summary>
        /// 额外操作
        /// </summary>
        /// <param name="id"></param>
        private static void ExtraOperation(int id)
        {
            //这里是通过拼接字符串进行一些相对耗时的操作
            var s = "";

            for (var i = 0; i < 6000; i++)
            {
                s += i;
            }

            Console.WriteLine($"id = {id} 的 ExtraOperation 方法完成：{Watch.ElapsedMilliseconds} ms");
        }


        #endregion


        #region 使用异步编程

        private static void  WhitAsync ()
        {
            //启动计时器
            Watch.Start();

            const string url1 = "http://www.cnblogs.com/";
            const string url2 = "http://www.cnblogs.com/liqingwen/";

            //两次调用 CountCharactersAsync 方法（异步下载某网站内容，并统计字符的个数）
            Task<int> t1 = CountCharactersAsync(1, url1);
             int  result1= t1.Result;
            Task<int> t2 = CountCharactersAsync(2, url2);
            int result2 = t2.Result;
            


            //三次调用 ExtraOperation 方法（主要是通过拼接字符串达到耗时操作）
            for (var i = 0; i < 3; i++)
            {
                ExtraOperation(i + 1);
            }

            //控制台输出
            Console.WriteLine($"{url1} 的字符个数：{t1.Result}");
            Console.WriteLine($"{url2} 的字符个数：{t2.Result}");

            Console.Read();
        }

        /// <summary>
        /// 统计字符个数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        private static async Task<int> CountCharactersAsync(int id, string address)
        {
            var wc = new WebClient();
            Console.WriteLine($"开始调用 id = {id}：{Watch.ElapsedMilliseconds} ms");

            var result = await wc.DownloadStringTaskAsync(address);
            Console.WriteLine($"调用完成 id = {id}：{Watch.ElapsedMilliseconds} ms");

            return result.Length;
        }

      

        #endregion


    }
}
