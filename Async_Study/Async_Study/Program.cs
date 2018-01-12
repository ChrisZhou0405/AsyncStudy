﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_Study
{
    class Program
    {
        static void Main(string[] args)
        {

            CallerwithAsync();

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

    }
}
