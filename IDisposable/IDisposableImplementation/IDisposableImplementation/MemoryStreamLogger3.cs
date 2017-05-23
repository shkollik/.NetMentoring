using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentoring
{
    class MemoryStreamLogger3
    {
        private FileStream memoryStream;
        private StreamWriter streamWriter;

        public MemoryStreamLogger3()
        {
        }

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
