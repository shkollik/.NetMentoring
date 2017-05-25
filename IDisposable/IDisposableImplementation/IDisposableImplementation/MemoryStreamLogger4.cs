using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentoring
{
    class MemoryStreamLogger4 : IDisposable
    {
        private FileStream memoryStream;
        private StreamWriter streamWriter;
        public MemoryStreamLogger4()
        {
            memoryStream = new FileStream(@"D:\.NET MENTORING PROGRSM\log.txt", FileMode.OpenOrCreate);
            streamWriter = new StreamWriter(memoryStream);
        }

        public void Dispose()
        {
            if (streamWriter != null)
            {
                streamWriter.Dispose();
                streamWriter = null; 
            }
        }

        public void Log(string message)
        {
            if (streamWriter == null) return;

            streamWriter.Write(message);
        }
    }
}
