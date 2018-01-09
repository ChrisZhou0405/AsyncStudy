using System;
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
            Greeting("Christ");
        }

        static string Greeting( string name )
        {
            Task.Delay(3000).Wait();

            return "Hello"+ name;
        }
    }
}
