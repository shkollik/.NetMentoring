using System;
using System.Collections.Generic;
using System.IO;

namespace NetMentoring
{
    class MemoryStreamLogger3
    {
        private FileStream memoryStream;
        private StreamWriter streamWriter;

        public void Log(string message)
        {
            using(memoryStream = new FileStream(@"D:\.NET MENTORING PROGRSM\log.txt", FileMode.OpenOrCreate))
            {
                using (streamWriter = new StreamWriter(memoryStream))
                {
                    streamWriter.Write(message);
                }
            }
        }
    }
}
