using Struct_Iteration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Struct_Iterarion
{
    class Example
    {
       static void Main()
        {
            var points = new List<Point>(Enumerable.Range(1, 10).Select(p => new Point()));

            for (int i = 0; i < points.Count; i++)
            {
                Point p = points[i];
                p.IncX();
                points[i] = p;
            }

            foreach(var p in points)
            {
                Console.WriteLine(p.X);
            }

            Console.ReadKey();
        }
    }
}
