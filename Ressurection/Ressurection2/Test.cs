using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ressurection2
{
    class Test
    {
        static void Main(string[] args)
        {
            Create();
            for (int i = 0; i < 5; i++)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();

                Console.WriteLine(A.intA != null ? "Alive" : "Dead"); 
            }
        }

        private static void Create()
        {
            new A();
        }
    }
}
