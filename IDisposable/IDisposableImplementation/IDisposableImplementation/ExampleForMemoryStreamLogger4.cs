using System;

namespace NetMentoring
{
    internal class ExampleForMemoryStreamLogger4
    {
        //private static void Main(string[] args)
        //{            
        //    for(var i = 0; i < 10000; i++)
        //        WriteLog("Interation number #" + i);

        //    Console.WriteLine("Finished");
        //    Console.ReadKey();
        //}

        private static void WriteLog(string str)
        {
            using (var logger = new MemoryStreamLogger4())
            {
                logger.Log(str);
            }
        }
    }
}
