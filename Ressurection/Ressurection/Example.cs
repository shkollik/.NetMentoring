using Ressurection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ressurection
{
    class Example
    {
        static void Main(string[] args)
        {
            new SomeType();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Finish");
            Console.ReadKey();
        }

    }
}
