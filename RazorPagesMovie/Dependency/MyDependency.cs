using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Dependency
{
    public class MyDependency
    {
        public MyDependency()
        {

        }

        public Task WriteMessage(string message)
        {
            Console.WriteLine($"MyDependency.WriteMessage called. Message:{message}");
            return Task.FromResult(0);
        }
    }
}
